using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveData : MonoBehaviour {
	public Button SaveButton;
	public Slider widthSlider;
	public Slider HeightSlider;
	public InputField seedInput;
	public Dropdown seedMode;
	public Slider musicSlider;
	public Slider sfxSlider;
	public Dropdown amountOfPlayers;

	
	// Use this for initialization
	void Start () {
		SaveButton.onClick.AddListener (SaveSettings);
	}
	void SaveSettings () {
		PlayerPrefs.SetInt ("setSeedMode", seedMode.value);
		PlayerPrefs.SetString ("customSeed", seedInput.text);
		PlayerPrefs.SetInt ("playerNum", amountOfPlayers.value);
		PlayerPrefs.SetFloat ("currentWidth", widthSlider.value);
		PlayerPrefs.SetFloat ("currentHeight", HeightSlider.value);
		PlayerPrefs.SetFloat ("musicVolume", musicSlider.value);
		PlayerPrefs.SetFloat ("sfxVolume", sfxSlider.value);
		GameManager.instance.musicSource.volume = PlayerPrefs.GetFloat ("musicVolume") / 100f;
		
	}
}
