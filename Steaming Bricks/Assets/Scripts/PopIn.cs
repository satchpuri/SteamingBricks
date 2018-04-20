﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR;

public class PopIn : MonoBehaviour {

	private bool active;
	public bool Active { get { return active; } }

	// Use this for initialization
	void Start () {
		//make object invisible on startup
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {}

	//This should LERP or SLERP if there is time.
	public void Toggle() {

		if (active) {
			transform.localScale = Vector3.zero;
			active = false;
		} else if (!active) {
			transform.localScale = new Vector3 (.00015f, .00015f, .00015f);
			active = true;
		}
		
	}
}
