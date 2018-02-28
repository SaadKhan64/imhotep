﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/*
 * Listen every Frame, if the current selected Gameobject is an InputField. 
 * If it is, it will activate the Keyboard-Gameobject.
 */
public class KeyboardListener : MonoBehaviour  {

	public GameObject keyboard;
	//Script
	public KeyboardControll controller;
	//current selected Gameobject
	private GameObject selected;
	public GameObject annotationControl;
	// Use this for initialization
	void Start () {
		if (keyboard == null) {
			keyboard = GameObject.FindWithTag ("Keyboard");
		}
		if (annotationControl == null) {
			annotationControl = GameObject.FindWithTag("AnnotationControl");
		}
	}
	
	// Update is called once per frame
	void Update () {
		selected = EventSystem.current.currentSelectedGameObject;
		if (selected != null && selected.name=="InputField" ) {
			if (controller != null && selected.GetComponent<InputField> ().tag.CompareTo("Keyboard")!=0  ) {
				controller.selectedInputField = selected.GetComponent<InputField> ();
				controller.oldText = controller.selectedInputField.text;
				controller.keyboardInputField.text = controller.selectedInputField.text;
				controller.keyboardInputField.ActivateInputField ();
				keyboard.SetActive (true);
			}

		}
	}
}
