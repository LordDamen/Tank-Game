using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankMover))]
[RequireComponent(typeof(TankShooter))]

public class TankData : MonoBehaviour {

	public float moveSpeed;
	public float ReverseSpeed;
	public float turnSpeed;
	public float delay;
	public float score;
	public float health;
	public float retreatHealth;
	public float maxHealth;
	public float regenAmount; 
	public float PlayerDmg;
	public string bulletTag;
	public float fleeDistance = 1.0f;
	// Other Tank Components
	[HideInInspector] public TankMover mover;
	[HideInInspector] public TankShooter shooter;

	void Start() {
		mover = GetComponent<TankMover> ();
		shooter = GetComponent<TankShooter> ();
	}
}
