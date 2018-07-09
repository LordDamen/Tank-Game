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
        // this is checking if the designer set the level to use the seed of the day
		if (GameManager.instance.seedOfTheDay == true) {
            //if it is then we use the seed that is set by the gameManager for the inital state of random
			Random.InitState (GameManager.instance.seed);
            //then we generate the world
			WorldGen ();
            // the same is true if the designer just wants to make a set seed function as well
		} else if (GameManager.instance.designerSeed == true) {
			Random.InitState (GameManager.instance.seed);
			WorldGen ();
		} else {
			WorldGen ();
		}

	}

	void Update () {
        // if the player doesnt exist then we will choose a random tile and generate him on that tile
		if (gm.player == null) {
			int rand = Random.Range (0, Tiles.Count);
			GameObject bob = Tiles [rand];
			Instantiate (gm.ThePlayer, bob.transform.localPosition, bob.transform.localRotation);
		}
	}
	public void WorldGen () {
        // for the current row repeat inside until the rows have been reached
		for (int currentRow = 0; currentRow < numberOfRows; currentRow++) 
		{
            // then do the same for collums
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