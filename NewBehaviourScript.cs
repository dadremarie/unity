using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {


	[HideInInspector] public bool facingRight=true;
	[HideInInspector] public bool jump = true;

	public float moveForce = 365f;
	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
