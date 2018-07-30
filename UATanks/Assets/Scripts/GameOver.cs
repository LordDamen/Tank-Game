using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public GameManager gm;
	public TankData player1;
	public TankData player2;
	// Use this for initialization
	void Start () {
		player1 = gm.ThePlayer.GetComponent<TankData>();
		player2 = gm.ThePlayer2.GetComponent<TankData>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.lives == 0 && player2.lives == 0) {
		
		}
	}
}
