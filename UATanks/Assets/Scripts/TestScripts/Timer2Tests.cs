using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer2Tests : MonoBehaviour {

	public float delay;
	public float lastOutputTime;

	// Use this for initialization
	void Start () {
		lastOutputTime = Time.time - delay;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= lastOutputTime + delay) {
			SayHello ();
		}
	}

	void SayHello() {
		Debug.Log ("Hello");
		// store the time this event occurred
		lastOutputTime = Time.time;
	}
}
