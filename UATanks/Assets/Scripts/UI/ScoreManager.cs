using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public TankData data;
	public Text scoreText;
	public Text healthText;
	public Text livesText;
	public Text deathText;
	private float playerNumberModifer;
	private int ActualPlayer;
	// Use this for initialization
	void Start () {
		deathText = GameObject.Find ("Death p" + ActualPlayer).GetComponent<Text> ();
		deathText.transform.position = new Vector3 (Screen.width * -1, Screen.height * -1);
	}
	
	// Update is called once per frame
	void Update () {
		if (data.lives >= 0) {
			scoreText.text = "" + data.score;
			healthText.text = "Health: " + data.health;
			livesText.text = "Lives: " + data.lives; 
		}
	}
	void OnEnable() {
		data = GetComponent<TankData> ();
		ActualPlayer = data.playerNumber + 1;
		scoreText = GameObject.Find ("Score p" + ActualPlayer).GetComponent<Text> ();
		healthText = GameObject.Find ("Health p" + ActualPlayer).GetComponent<Text> ();
		livesText = GameObject.Find ("Lives p" + ActualPlayer).GetComponent<Text> ();
		int numberOfPlayers = PlayerPrefs.GetInt ("playerNum");
		if (numberOfPlayers == 0) {
			scoreText.transform.position = new Vector3 (Screen.width - 90.0f, Screen.height - 20.0f, 1);
			healthText.transform.position = new Vector3 (90.0f, Screen.height - 20.0f, 1);
			livesText.transform.position = new Vector3 (90.0f, Screen.height - 40.0f, 1);
		} else {
			playerNumberModifer = data.playerNumber * 0.5f;
			scoreText.transform.position = new Vector3 (Screen.width *playerNumberModifer+Screen.width *0.5f -90.0f, Screen.height - 20.0f, 1);
			healthText.transform.position = new Vector3 (Screen.width *playerNumberModifer+90.0f, Screen.height  - 20.0f, 1);
			livesText.transform.position = new Vector3 (Screen.width *playerNumberModifer+90.0f, Screen.height - 40.0f, 1);
		}
	}
}
