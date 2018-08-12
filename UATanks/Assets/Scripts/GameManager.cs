using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    // this is the player instance
    public InputController player;
	public InptCtn2 player2;
    public GameObject ThePlayer;
	public GameObject ThePlayer2;
    public List<GameObject> waypoints;
    public TileManager Tm;
    public int seed;
	public int seedMode;
    public AudioClip MenuMusic = new AudioClip();
    public AudioClip GameMusic = new AudioClip();
    public AudioSource musicSource = new AudioSource();
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
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume") / 100.0f;
    }
	void Update () {
		seedMode = PlayerPrefs.GetInt ("setSeedMode");
		if (seedMode == 1) {
				int n = int.Parse (System.DateTime.Now.ToString ("yyyyMMdd"));
				seed = n;

		} else if (seedMode == 2) {
			seed = int.Parse (PlayerPrefs.GetString ("customSeed"));

		}
        //musicSource.volume = PlayerPrefs.GetFloat("musicVolume") / 100;
    }
   public void MusicSwap ()
    {
        print("hello");
        if (musicSource.clip == this.MenuMusic)
        {
            if (GameMusic != null) { print("i hate my life"); }
            musicSource.clip = GameMusic;
            //musicSource.volume = PlayerPrefs.GetFloat("musicVolume") / 100;
            musicSource.Play();
        }
        /*if (musicSource.clip == this.GameMusic)
        {
            musicSource.clip = MenuMusic;
           // musicSource.volume = PlayerPrefs.GetFloat("musicVolume") / 100;
            musicSource.Play();
        }*/
    }
}

