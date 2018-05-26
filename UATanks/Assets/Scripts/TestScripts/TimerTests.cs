using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTests : MonoBehaviour {

	public float delay;
	private float nextOutputTime;

	// Use this for initialization
	void Start () {
		nextOutputTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {
		// Every X seconds
		if (Time.time >= nextOutputTime) {
			// Say "Hello"
			SayHello ();
			// Set the next time
			nextOutputTime = Time.time + delay;
		}
	}

	void SayHello () {
		Debug.Log ("Hello!");
	}
}
