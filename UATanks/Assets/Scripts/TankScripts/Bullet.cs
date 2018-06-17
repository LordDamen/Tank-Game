using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public TankData Player;
	public TankData Enemy;
	[HideInInspector] public TankData ShooterStats;
	public float delay;
	public float speed;
	public Rigidbody rb;
	[HideInInspector] private bool JustFired;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
		rb = GetComponent<Rigidbody> ();
		JustFired = true;
		rb.AddForce(transform.forward * speed);
		if (gameObject.tag == "Enemy") {
			rb.AddForce (transform.right * Random.Range (-20f, 1f));

		}
	}
	
	// Update is called once per frame
	void Update () {
		// setting the inital velocity



	
	}
	void OnCollisionEnter (Collision Other) {
		// this is checking if the player is tagged an enemy
		if (Other.gameObject.tag == "Enemy") {
			// this then gets the stats of the enemy
			Enemy = Other.gameObject.GetComponent<TankData> ();
			// then it deals the assigned damage
			Enemy.health -= ShooterStats.PlayerDmg;
			// if health is less than 0 destroy the object that it hit
			if (Enemy.health <= 0) {
				Destroy (Other.gameObject);
			}
		}
		// this is checking if the thing shot is tagged as a player
	
		if (Other.gameObject.tag == "Player") {
			// this then gets the stats of the enemy
			Player = Other.gameObject.GetComponent<TankData> ();
			// then it deals the assigned damage
			Player.health -= ShooterStats.PlayerDmg;
			// if health is less than 0 destroy the object that it hit
			if (Player.health <= 0) {
				Destroy (Other.gameObject);
			}
		}
		Destroy (gameObject);
	}
	// sets the damage on exit of the trigger box
	void OnTriggerExit (Collider other) {
		if (JustFired == true) {
			ShooterStats = other.gameObject.GetComponent<TankData> ();
			JustFired = false;
		}
	}

}
