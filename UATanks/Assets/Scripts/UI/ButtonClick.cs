using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    public AudioClip clickSound;
    public List<Button> buttonList;

    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].onClick.AddListener(buttonSound);
			AudioListener.volume = PlayerPrefs.GetFloat ("sfxVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
		AudioListener.volume = PlayerPrefs.GetFloat ("sfxVolume");
    }

    void buttonSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, gameObject.transform.position);
	
    }
}