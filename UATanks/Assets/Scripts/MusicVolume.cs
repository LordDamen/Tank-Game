using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volume : MonoBehaviour {
    public AudioSource sound;
    // Use this for initialization
    private void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    void Start () {
        sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
