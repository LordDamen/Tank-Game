﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	void OnCollisionEnter (Collision other) {
		Destroy (gameObject);
	}
}
