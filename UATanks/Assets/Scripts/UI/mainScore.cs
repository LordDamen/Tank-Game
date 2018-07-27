using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainScore : MonoBehaviour {
	public Text sText;
	// Use this for initialization
	void Start () {
		sText.text = "HighScore:  " + PlayerPrefs.GetInt ("highscore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
