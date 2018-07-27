using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("playerNum") != 1) {
			gameObject.SetActive (false);
		}
	}
}
