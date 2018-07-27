using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScreen : MonoBehaviour {
	public Text Score1;
	public Text Score2;
	public Text HighScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Score1.text = "Player 1 Score: " + PlayerPrefs.GetInt ("tempScoreOne");
		Score2.text = "Player 2 Score: " + PlayerPrefs.GetInt ("tempScoreTwo");
		HighScore.text = "The Current Highscore is: " + PlayerPrefs.GetInt ("highScore");

	}
}
