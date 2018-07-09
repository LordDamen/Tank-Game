using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
	public List<GameObject> powerUps;
	private TankData Data;
	public float timeBetweenSpawns;
	private float RespawnTime;
	public GameObject thePower;
	public GameObject objectToSpawn;
	public int rand;
	public bool CollectedPUP;
	// Use this for initialization
	void Start () {
		thePower = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		RespawnTime -= Time.deltaTime;
		if (RespawnTime <= 0 && CollectedPUP == true) 
		{
			RespawnTime = Time.time + timeBetweenSpawns;
			this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y+5);
			Data.delay = 4;
			Data.moveSpeed = 5;
			CollectedPUP = false;
			// Reset timer
			RespawnTime = timeBetweenSpawns;
		}

	}
	void OnCollisionEnter (Collision Other) {
		if (Other.gameObject.tag != "Env") {
			Data = Other.gameObject.GetComponent<TankData> ();
			if (thePower.name == "FireRate") {
				Other.gameObject.GetComponent<TankData>().delay = -2;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
			}
			if (thePower.name == "SpeedBoost") {
				Other.gameObject.GetComponent<TankData>().moveSpeed += 10;
				Other.gameObject.GetComponent<TankData>().turnSpeed += 10;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
			}
			if (thePower.name == "HealthBoost") {
				Other.gameObject.GetComponent<TankData>().health += 10;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
			}
			CollectedPUP = true;
		}

	}

}
