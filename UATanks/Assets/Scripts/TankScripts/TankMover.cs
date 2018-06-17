using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour {

	[HideInInspector] public Transform tf;
	private TankData data;
	private InputController control;
	// Use this for initialization
	void Start () {
		// just grabing required components
		control = GetComponent<InputController> ();
		tf = GetComponent<Transform> ();
		data = GetComponent<TankData> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if the bool forward is true, which we check for in the input conroler is true then move forward
		if (control.forward == true) {
			Move (1);
		}
		// if the bool back is true, which we check for in the input conroler is true then move backward
		if (control.back == true) {
			Move (-1);
		}
	

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
