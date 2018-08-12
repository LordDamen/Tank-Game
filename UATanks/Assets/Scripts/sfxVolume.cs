using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SfxVolume : MonoBehaviour {
    public AudioSource sound;
    // Use this for initialization
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        sound.Play();
    }
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume")/100;
    }
}
