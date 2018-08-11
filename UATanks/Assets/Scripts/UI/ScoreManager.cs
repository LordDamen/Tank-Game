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
	public AudioSource GameOver;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (data.lives >= 0) {
			scoreText.text = "" + data.score;
			healthText.text = "Health: " + data.health;
			livesText.text = "Lives: " + data.lives; 

		} else {
			deathText.transform.position = new Vector3 (Screen.width * -1, Screen.height * -1);
			data.moveSpeed = 0;
			data.delay = 100000;
			GameOver.Play();
		}
		GameOver.volume = PlayerPrefs.GetFloat ("sfxVolume");
	}
	void OnEnable() {
		data = GetComponent<TankData> ();
		ActualPlayer = data.playerNumber;
		deathText = GameObject.Find ("Death p" + ActualPlayer).GetComponent<Text> ();
		deathText.transform.position = new Vector3 (Screen.width * -1, Screen.height * -1);
		scoreText = GameObject.Find ("Score p" + ActualPlayer).GetComponent<Text> ();
		healthText = GameObject.Find ("Health p" + ActualPlayer).GetComponent<Text> ();
		livesText = GameObject.Find ("Lives p" + ActualPlayer).GetComponent<Text> ();

		int numberOfPlayers = PlayerPrefs.GetInt ("playerNum");
		if (numberOfPlayers == 0) {
			scoreText.transform.position = new Vector3 (Screen.width - 90.0f, Screen.height - 20.0f, 1);
			healthText.transform.position = new Vector3 (90.0f, Screen.height - 20.0f, 1);
			livesText.transform.position = new Vector3 (90.0f, Screen.height - 40.0f, 1);
		} else {
			playerNumberModifer = data.playerNumber * .5f;
			scoreText.transform.position = new Vector3 (Screen.width *playerNumberModifer+Screen.width *0.5f -90.0f, Screen.height - 20.0f, 1);
			healthText.transform.position = new Vector3 (Screen.width *playerNumberModifer+90.0f, Screen.height  - 20.0f, 1);
			livesText.transform.position = new Vector3 (Screen.width *playerNumberModifer+90.0f, Screen.height - 40.0f, 1);
		}
	}
}
