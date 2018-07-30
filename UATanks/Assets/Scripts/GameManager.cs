using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    // this is the player instance
    public InputController player;
    public InputController player2;
    public GameObject ThePlayer;
    public List<GameObject> waypoints;
    public TileManager Tm;
    public int seed;
	public int seedMode;
    // Use this for initialization
    // check if it exitsts if it does then destroy and this is the new one
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        
    }
	void Update () {
		seedMode = PlayerPrefs.GetInt ("setSeedMode");
		if (seedMode == 1) {
				int n = int.Parse (System.DateTime.Now.ToString ("yyyyMMdd"));
				seed = n;

		} else if (seedMode == 2) {
			seed = int.Parse (PlayerPrefs.GetString ("customSeed"));

		}
	}
}

