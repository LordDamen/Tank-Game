using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour {
	public GameObject Bullet;
	private TankData data;
	private float Timer;
	public Transform x;
	public GameObject NewBullet;
	//public float delay;
	// Use this for initialization
	void Start () {
		//x = GetComponent<Transform> ();
		data = GetComponent<TankData> ();
		Timer = Time.time;
		//delay = TankData.delay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Fire () {
		if (Time.time >= Timer) {
			Timer = Time.time + data.delay;
			NewBullet = Instantiate (Bullet, x.position,x.rotation);
			NewBullet.tag = data.bulletTag;


		}
	}
}
