using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicVolume : MonoBehaviour {
    public AudioSource sound;
    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start () {
        sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume")/100;
    }
}
