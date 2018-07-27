using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderText : MonoBehaviour {
	public Text Editable;
	public Slider slider;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		Editable.text = Editable.name + ": " + slider.value;
	}
}
