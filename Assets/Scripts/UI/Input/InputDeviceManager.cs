﻿using UnityEngine;
using System.Collections.Generic;



public class InputDeviceManager : MonoBehaviour {

    public enum RayInfoStates
    {
        rayHitsUI,
        rayHitsMesh,
        rayHitsBackground
    }

    public RayInfoStates rayInfo = RayInfoStates.rayHitsBackground;

    public GameObject currentInputDevice { get; set; } //Defines with game object controlls the input

    private List<GameObject> deviceList = new List<GameObject>(); //List of registered input devices (e.g. mouse, vive contoller ...) 

    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        //Update rayInfo
        if (UI.UICore.instance.mouseIsOverUIObject)
        {
            rayInfo = RayInfoStates.rayHitsUI;
        }
        else
        {
            if (deviceList.Count <= 0)
            {
                return;
            }

            RaycastHit hit;
            Ray ray = currentInputDevice.GetComponent<InputDeviceInterface>().createRay();
            LayerMask onlyMeshViewLayer = 1000000000; // hits only the mesh view layer
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, onlyMeshViewLayer))
            {
                rayInfo = RayInfoStates.rayHitsMesh;
            }
            else
            {
                rayInfo = RayInfoStates.rayHitsBackground;
            }
        }
    }

    public bool registerInputDevice(GameObject g)
    {
        if(g.GetComponent<InputDeviceInterface>() == null)
        {
            return false;
        }

        deviceList.Add(g);
        currentInputDevice = g; //TODO how to change currentInputDevice in game?

        return true;
    }
}
