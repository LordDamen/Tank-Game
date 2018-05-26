using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public TankData pawn;

	public KeyCode forwardKey = KeyCode.W;
	public KeyCode turnRightKey = KeyCode.A;
	public KeyCode turnLeftKey = KeyCode.D;
	public KeyCode backKey = KeyCode.S;
	public KeyCode space = KeyCode.Space;
	[HideInInspector] public bool forward;
	[HideInInspector] public bool back;
	// Use this for initialization
	void Start () {
		GameManager.instance.player = this;
		pawn = GetComponent<TankData> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (forwardKey)) {
			forward = true;
		} else {
			forward = false;
		}
		if (Input.GetKey (backKey)) {
			back = true;
		} else {
			back = false;
		}
		if (Input.GetKey (turnRightKey)) {
			pawn.mover.Turn (-1);
		}
		if (Input.GetKey (turnLeftKey)) {
			pawn.mover.Turn (1);
		}
		if (Input.GetKeyDown (space)) {
			pawn.shooter.Fire ();
		}
	}
}