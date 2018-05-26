using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject Sullet;
	[HideInInspector] public TankData Player;
	[HideInInspector] public TankData Enemy;
	[HideInInspector] public TankData ShooterStats;
	public float delay;
	public float speed;
	private bool JustFired;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
		JustFired = true;
	}
	
	// Update is called once per frame
	void Update () {
		Sullet.GetComponent<Rigidbody> ().velocity = Sullet.transform.forward * speed;


	
	}
	void OnCollisionEnter (Collision Other) {
		if (Other.gameObject.tag == "Enemy") {
			Enemy = Other.gameObject.GetComponent<TankData> ();
			Enemy.health -= ShooterStats.PlayerDmg;
			if (Enemy.health <= 0) {
				Destroy (Other.gameObject);
			}
		}
		if (Other.gameObject.tag == "Player") {
			Player = Other.gameObject.GetComponent<TankData> ();
			Player.health -= ShooterStats.EnemyDmg;
			if (Player.health <= 0) {
				Destroy (Other.gameObject);
			}
		}
		Destroy (gameObject);
	}
	void OnTriggerExit (Collider triger) {
		if (JustFired == true) {
			ShooterStats = triger.gameObject.GetComponent<TankData> ();
			JustFired = false;
		}
	}

}
