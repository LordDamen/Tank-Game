using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour {

	private CharacterController cc;
	[HideInInspector] public Transform tf;
	private TankData data;
	private InputController control;
	// Use this for initialization
	void Start () {
		control = GetComponent<InputController> ();
		tf = GetComponent<Transform> ();
		data = GetComponent<TankData> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (control.forward == true) {
			transform.position += transform.forward * data.moveSpeed * Time.deltaTime;
		}
		if (control.back == true) {
			transform.position -= transform.forward * data.ReverseSpeed * Time.deltaTime;
		}
	}
		

	public void Turn ( float direction ) {
		// Turn in the direction at turn speed
		tf.Rotate(0, Mathf.Sign(direction) * data.turnSpeed * Time.deltaTime, 0);
	}

}
