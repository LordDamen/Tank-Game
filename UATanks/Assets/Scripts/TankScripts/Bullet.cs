using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[HideInInspector] public GameObject bullet;
	[HideInInspector] public TankData Player;
	[HideInInspector] public TankData Enemy;
	[HideInInspector] public TankData ShooterStats;
	public float delay;
	public float speed;
	[HideInInspector] private bool JustFired;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
		JustFired = true;
	}
	
	// Update is called once per frame
	void Update () {
		// setting the inital velocity
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * speed;


	
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
	void OnTriggerExit (Collider triger) {
		if (JustFired == true) {
			ShooterStats = triger.gameObject.GetComponent<TankData> ();
			JustFired = false;
		}
	}

}
