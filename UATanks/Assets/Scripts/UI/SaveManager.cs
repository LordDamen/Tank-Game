using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	void Awake () {
		if (!PlayerPrefs.HasKey ("highScore")) {
			PlayerPrefs.SetInt ("highscore", 0);
		}
		if (!PlayerPrefs.HasKey ("setSeedMode")) {
			PlayerPrefs.SetInt ("setSeedMode", 0);
		}
		if (!PlayerPrefs.HasKey ("customSeed")) {
			PlayerPrefs.SetString ("customSeed", "0");
		}
		if (!PlayerPrefs.HasKey ("playerNum")) {
			PlayerPrefs.SetInt ("playerNum", 0);
		}
		if (!PlayerPrefs.HasKey ("currentWidth")) {
			PlayerPrefs.SetInt ("currentWidth", 3);
		}
		if (!PlayerPrefs.HasKey ("currentHeight")) {
			PlayerPrefs.SetInt ("currentHeight", 3);
		}
		if (!PlayerPrefs.HasKey ("musicVolume")) {
			PlayerPrefs.SetInt ("musicVolume", 100);
		}
		if (!PlayerPrefs.HasKey ("sfxVolume")) {
			PlayerPrefs.SetInt ("sfxVolume", 100);
		}
		PlayerPrefs.SetInt ("PlayerOneLives",3);
		PlayerPrefs.SetInt ("PlayerTwoLives",3);
		PlayerPrefs.SetInt ("tempScoreOne",0);
		PlayerPrefs.SetInt ("tempScoreTwo", 0);
	}

}
