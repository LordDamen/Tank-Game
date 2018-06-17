using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	// this is the player instance
	public InputController player;
	public GameObject[] waypoints;
	// Use this for initialization
	// check if it exitsts if it does then destroy and this is the new one
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
}
