using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public GameManager gm;
	public TankData player1;
	public TankData player2;
    public GameObject inactve1;
    public GameObject actve1;
    // Use this for initialization
    void Start () {
		player1 = gm.ThePlayer.GetComponent<TankData>();
		player2 = gm.ThePlayer2.GetComponent<TankData>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("playerNum") > 0)
        {
            if (player1.lives == 0 && player2.lives == 0)
            {
                inactve1.SetActive(false);
                actve1.SetActive(true);
            }
        } else if(player1.lives ==0)
        {
            inactve1.SetActive(false);
            actve1.SetActive(true);
        }
	}
}
