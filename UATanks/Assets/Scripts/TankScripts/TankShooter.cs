using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour {
	public GameObject Bullet;
	private TankData data;
	private float Timer;
	public Transform firePoint;
	public GameObject NewBullet;
	//public float delay;
	// Use this for initialization
	void Start () {
		//getting requied components
		data = GetComponent<TankData> ();
		// this is the inital value for the timer
		Timer = Time.time;
		//delay = TankData.delay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Fire () {
		// if the time irl is less then the delay then you can fire
		if (Time.time >= Timer) {
			// adding time to make sure timer is happening
			Timer = Time.time + data.delay;
				// create the bullet
				//Quaternion targetRotation = Quaternion.Euler(0,Random.Range(0,5),0);
				NewBullet = Instantiate (Bullet, firePoint.position, firePoint.rotation);
				print ("shoot"); 
				NewBullet.tag = data.bulletTag;
		}
	}
}
