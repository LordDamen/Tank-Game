using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUpManager : MonoBehaviour {
	public List<GameObject> powerUps;
	public int powType;
	private GameObject newPowUp;
	void Start () {
		if (GameManager.instance.seedMode != 0) {
			Random.InitState (GameManager.instance.seed);
			powType = Random.Range (0, powerUps.Count);
		} else {
			powType = Random.Range (0, powerUps.Count);
		}
		newPowUp = Instantiate (powerUps [powType]);
		newPowUp.transform.parent = this.transform;
		newPowUp.transform.localPosition = new Vector3 (0, 1, 0);

	}
	void Update () {
	}
}
