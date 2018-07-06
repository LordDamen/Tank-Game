using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	public GameObject[] Tiles;
	public int NumOfTiles;
	public int NumOfRows;
	public int NumOfCollum;



	void Start () {
		GameManager.instance.ListOfTiles = this;
	}

	void Update () {

	}
}