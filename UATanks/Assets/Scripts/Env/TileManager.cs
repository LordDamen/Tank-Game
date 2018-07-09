using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	public GameManager gm;
	//public List<Room> rooms;
	public List<GameObject> Tiles;
	public float TileZWidth;
	public float TileXWidth;

	public int numberOfCollums;
	public int numberOfRows;


	public List<GameObject> TilePrefabs;

	void Start () {
		if (GameManager.instance.seedOfTheDay == true) {
			Random.InitState (GameManager.instance.seed);
			WorldGen ();
		} else if (GameManager.instance.designerSeed == true) {
			Random.InitState (GameManager.instance.seed);
			WorldGen ();
		} else {
			WorldGen ();
		}

	}

	void Update () {
		if (gm.player == null) {
			print ("player?");
			int rand = Random.Range (0, Tiles.Count);
			GameObject bob = Tiles [rand];
			Instantiate (gm.ThePlayer, bob.transform.localPosition, bob.transform.localRotation);
		}
	}
	public void WorldGen () {
		for (int currentRow = 0; currentRow < numberOfRows; currentRow++) 
		{
			for (int currentCol = 0; currentCol < numberOfCollums; currentCol++) 
			{
				// start generating random tiles
				int rand = Random.Range(0, TilePrefabs.Count);
				GameObject newTile = Instantiate(TilePrefabs[rand]) as GameObject;
				//now to give it a name
				newTile.name = "Tile (" + currentCol + "," + currentRow + ")";
				//Make the new tile into a child of the other object
				newTile.transform.parent = this.transform;

				//now to move it into position
				float Xpos = currentCol *TileXWidth;
				float Zpos = currentRow * TileZWidth;
				newTile.transform.localPosition = new Vector3 (Xpos, 0.0f, Zpos);
				Tiles.Add (newTile);
			}
		}
	}
}