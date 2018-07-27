using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class resetButton : MonoBehaviour {
	public Button resetB;

	// Use this for initialization
	void Start () {
		resetB.onClick.AddListener (ResetAll);
	}
	void ResetAll() {
		PlayerPrefs.SetInt ("highscore", 0);
		PlayerPrefs.SetInt ("setSeedMode", 0);
		PlayerPrefs.SetString ("customSeed", "0");
		PlayerPrefs.SetInt ("playerNum", 0);
		PlayerPrefs.SetFloat ("currentWidth", 3);
		PlayerPrefs.SetFloat ("currentHeight", 3);
		PlayerPrefs.SetFloat ("highscore", 100);
		PlayerPrefs.SetFloat ("highscore", 100);
	}
}
