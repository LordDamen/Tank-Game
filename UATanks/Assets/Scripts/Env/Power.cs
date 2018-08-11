using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
	[HideInInspector] public TankData data;
	private float respawnTime = 0.0f;
	public float respawnDelay;
	private bool respawnNow;
	public AudioClip powUpSound;


	void Update () {
		if (Time.time >= respawnTime && respawnNow == false)	{
			if (gameObject.tag == "RateOfire") {
				data.delay += 0.25f;
			}
			if (gameObject.tag == "Speed") {
				data.turnSpeed -= 2;
				data.moveSpeed -= 3;
				data.ReverseSpeed -= 3;
			}
			transform.localPosition = new Vector3 (0, 1, 0);
			respawnNow = true;
		}
	}
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player") {
			data = other.gameObject.GetComponent<TankData>();
		
			if (gameObject.tag == "RateOfire") {
				data.delay -= 0.25f;
				AudioSource.PlayClipAtPoint (powUpSound, this.transform.position, PlayerPrefs.GetFloat ("sfxVolume"));
				transform.localPosition = new Vector3 (0, -5, 0);
				respawnTime = Time.time + respawnDelay;
			}
			if (gameObject.tag == "Health") {
				data.health += 10; 
				if (data.health > data.maxHealth){
					data.health = data.maxHealth;
				}
				AudioSource.PlayClipAtPoint (powUpSound, this.transform.position, PlayerPrefs.GetFloat ("sfxVolume"));
				transform.localPosition = new Vector3 (0, -5, 0);
				respawnTime = Time.time + respawnDelay;
			}
			if (gameObject.tag == "Speed") {
				data.turnSpeed += 2;
				data.moveSpeed += 3;
				data.ReverseSpeed += 3;
				AudioSource.PlayClipAtPoint (powUpSound, this.transform.position, PlayerPrefs.GetFloat ("sfxVolume"));
				transform.localPosition = new Vector3 (0, -5, 0);
				respawnTime = Time.time + respawnDelay;
			}
			respawnNow = false;
		} 
	}
}