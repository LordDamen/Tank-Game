using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntSettings : MonoBehaviour {

	public Button optionsButton;
	public Slider widthSlider;
	public Slider HeightSlider;
	public InputField seedInput;
	public Dropdown seedMode;
	public Slider musicSlider;
	public Slider sfxSlider;
	public Dropdown amountOfPlayers;

	// Use this for initialization
	void Start () {
		optionsButton.onClick.AddListener (IntalSettings);
	}
	void IntalSettings () {
		widthSlider.value = PlayerPrefs.GetFloat ("currentWidth");
		HeightSlider.value = PlayerPrefs.GetFloat ("currentHeight");
		seedInput.text = PlayerPrefs.GetString ("customSeed");
		seedMode.value = PlayerPrefs.GetInt ("setSeedMode");
		musicSlider.value = PlayerPrefs.GetFloat ("musicVolume");
		sfxSlider.value = PlayerPrefs.GetFloat ("sfxVolume");
		amountOfPlayers.value = PlayerPrefs.GetInt ("playerNum");
	}
}
