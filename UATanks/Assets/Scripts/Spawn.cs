using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject entity;

	// Use this for initialization
	void Awake() {
		Instantiate (entity, this.transform.position, this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
