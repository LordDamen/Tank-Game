using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour {

	[HideInInspector] public Transform tf;
	private TankData data;
	// Use this for initialization
	void Start () {
		// just grabing required components
		tf = GetComponent<Transform> ();
		data = GetComponent<TankData> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void Turn ( float direction ) {
		// Turn in the direction at turn speed
		tf.Rotate(0, Mathf.Sign(direction) * data.turnSpeed * Time.deltaTime, 0);
	}
	public void Move(int Negative) {
		tf.position += tf.forward * data.moveSpeed * Time.deltaTime* Negative; 
		//print ("yes");
	}

}
