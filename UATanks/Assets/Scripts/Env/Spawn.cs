using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public List<GameObject> EnemyToSpawn;
	public GameObject objectToSpawn;
	public GameObject spawnedObject;
	private Transform tf;
	public float timeBetweenSpawns;
	private float spawnCountdown;
	public int rand;
	public List<GameObject> waypoint;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		if (GameManager.instance.seedMode !=0 ) {
			Random.InitState (GameManager.instance.seed);
		}
		rand = Random.Range (0, EnemyToSpawn.Count);
		spawnCountdown = timeBetweenSpawns;
	}

	// Update is called once per frame
	void Update () {
		
		if (spawnedObject == null)
		{
			// countdown
			spawnCountdown -= Time.deltaTime;

			if (spawnCountdown <= 0) {
				// Spawn an object

				spawnedObject = Instantiate(EnemyToSpawn[rand], tf.position, tf.rotation) as GameObject;
				spawnedObject.GetComponent<AiControler> ().Waypoints = waypoint;
				// Reset timer
				spawnCountdown = timeBetweenSpawns;
			}
		}
	}

}