using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
	public List<GameObject> powerUps;
	private TankData Data;
	public float powerupRespawnTImer;
	private float RespawnTime;
	public GameObject thePower;
	public GameObject objectToSpawn;
	public int rand;
	public bool CollectedPUP;
	public AudioSource soundToMake;
	// Use this for initialization
	void Start () {
		thePower = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        // this is setting the timer for the respawn of the powerups
		RespawnTime -= Time.deltaTime;
        //then we check for it it is time to respawn the powerup
		if (RespawnTime <= 0 && CollectedPUP == true) 
		{


            RespawnTime = Time.time + powerupRespawnTImer;
            // hide the powerup instead of random generation TODO: Random Generation
            this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y+5);
            // then it resets all temp. powerups on the player
			Data.delay = 4;
			Data.moveSpeed = 5;
			CollectedPUP = false;
			// Reset timer
			RespawnTime = powerupRespawnTImer;
		}
		soundToMake.volume = PlayerPrefs.GetFloat ("sfxVolume");
	}
	void OnCollisionEnter (Collision Other) {
        // this checks for if the bullet if hitting it and if it does then it ignores it 
		if (Other.gameObject.tag != "Env") {
			Data = Other.gameObject.GetComponent<TankData> ();
            //these are the three different powerups that are inside of the game 
			if (thePower.name == "FireRate") {
				Other.gameObject.GetComponent<TankData>().delay = -2;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
				soundToMake.Play ();

            }

			if (thePower.name == "SpeedBoost") {
				Other.gameObject.GetComponent<TankData>().moveSpeed += 10;
				Other.gameObject.GetComponent<TankData>().turnSpeed += 10;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
				soundToMake.Play ();
            }
			if (thePower.name == "HealthBoost") {
				Other.gameObject.GetComponent<TankData>().health += 10;
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y-5);
				soundToMake.Play ();
			}
            // tells the game that you collected a powerup to start the respawn timer
			CollectedPUP = true;
		}

	}

}
