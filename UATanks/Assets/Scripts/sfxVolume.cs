using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sfxVolume : MonoBehaviour {
    public AudioSource sound;
    // Use this for initialization
    private void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    // Use this for initialization
    void Start () {
        sound.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
