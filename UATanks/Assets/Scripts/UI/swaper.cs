using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class swaper : MonoBehaviour {
	public Button reset;
	// Use this for initialization
	void Start () {
		reset.onClick.AddListener (switcher);
	}
	void switcher () {
		SceneManager.LoadScene ("resetSceen");
	}
}
