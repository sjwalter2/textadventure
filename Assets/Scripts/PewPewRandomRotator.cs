﻿using UnityEngine;
using System.Collections;

public class PewPewRandomRotator : MonoBehaviour {

	public float tumble;
	// Use this for initialization
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
