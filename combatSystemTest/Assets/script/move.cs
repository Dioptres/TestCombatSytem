﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movementManager.directionMove =new Vector3(Input.GetAxisRaw("Horizontal")/50,Input.GetAxisRaw ("Vertical")/50,0);
	}
}