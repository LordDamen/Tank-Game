using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer3Tests : MonoBehaviour {

	public float delay;
	private float countdown;

	// Use this for initialization
	void Start () {
		countdown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0) {
			SayHello ();
			countdown = delay;
		}

	}

	void SayHello() {
		Debug.Log ("Hello");

	}
}
