using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSeens : MonoBehaviour {

	void Awake () {
		SceneManager.LoadScene ("main");
	}
}
