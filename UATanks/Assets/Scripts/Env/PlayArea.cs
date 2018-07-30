using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {
	public TileManager Tm;
	public GameManager gm;
	public TankData Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider Other) {
		int rand = Mathf.RoundToInt(Random.Range (0, Tm.Tiles.Count));
		GameObject bob = Tm.Tiles [rand];
		Player = Other.GetComponent<TankData> ();
		Player.transform.localPosition = bob.transform.localPosition;
	}
}
