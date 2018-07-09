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
		// giving the gamemanager the idea of the player
		GameManager.instance.player = this;
		pawn = GetComponent<TankData> ();
	}
	
	// Update is called once per frame
	void Update () {
		// booliean logic for if the character is moving forward
		if (Input.GetKey (forwardKey)) {
			pawn.mover.Move (1);
		}
		// booliean logic for if the character is moving backward
		if (Input.GetKey (backKey)) {
			pawn.mover.Move (-1);
		} 
		// if the numer is positve then you rotate clockwise
		if (Input.GetKey (turnRightKey)) {
			pawn.mover.Turn (-1);
		}
		// if the numer is positve then you rotate counterclockwise
		if (Input.GetKey (turnLeftKey)) {
			pawn.mover.Turn (1);
		}
		// if the spacebar is pressed then it will use the timer and if enough time has passed then they can shoot again.
		if (Input.GetKey (space)) {
			pawn.shooter.Fire ();
		}
	}
}