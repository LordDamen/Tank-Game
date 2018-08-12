using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

    public Camera playerCam;
    private TankData Data;
    private int numOfPlayers;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        Data = GetComponent<TankData>();
        numOfPlayers = PlayerPrefs.GetInt("playerNum");
        if (numOfPlayers == 0)
        {
            playerCam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            playerCam.rect = new Rect(0.5f * (Data.playerNumber-1), 0.0f, 0.5f, 1.0f);
        }
    }
}
