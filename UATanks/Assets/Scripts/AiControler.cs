using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour {
	private TankData pawn;
	private TankMover mover;
	private TankShooter shoot;
	private int currentWaypoint = 0;
	public float closeEnough = 1.0f;
	public enum patrolStates { Flee,Waypoint,Chase,Patrol};
	public patrolStates aiStates;
	public Transform lastSeen;
	private float fleeTimer;
	public float fleeDelay;
	private float fireDelay;


	// Use this for initialization
	void Start () {
		mover = GetComponent<TankMover> ();
		pawn = GetComponent<TankData> ();
		shoot = GetComponent<TankShooter> ();

	}
	void Update () {
		//if (this.pawn.health <= this.pawn.retreatHealth) {
		//	aiStates = patrolStates.Flee;
		//}
		if (aiStates == patrolStates.Flee) {
			Flee ();
		}
		if (aiStates == patrolStates.Chase) {
			Chase ();
		}
		if (aiStates == patrolStates.Waypoint) {
			Waypoint ();
		}
		if (aiStates == patrolStates.Patrol) {
			Patrol ();
		}
	}


	protected void idle () {
	// Do Nothing!

	}
	protected void Chase () {
		// TODO: Create Chase function
		Movetowards(lastSeen);
		shoot.Fire ();
	}
	 protected void Waypoint () {
		//GameManager.instance.waypoints [currentWaypoint];

		if ( Vector3.Distance(GameManager.instance.waypoints[currentWaypoint].transform.position,transform.position ) >= closeEnough) {
			mover.Turn (1);
			Movetowards(GameManager.instance.waypoints[currentWaypoint].transform);
			if (Vector3.Distance (GameManager.instance.waypoints [currentWaypoint].transform.position, transform.position) < closeEnough) {
				currentWaypoint++;
				idle ();
				if (currentWaypoint == 4) {
					currentWaypoint = 0;

				}
			}
		} 
			
		//}
	}
	 protected void Patrol () {
		// DO nothing this is innate inside of the vision script
		mover.Move(1);

	}

		


	protected void Movetowards(Transform target) {
		transform.LookAt (target);
		mover.Move (1);
	}






	[SerializeField] private float HalfConeSize = 45f;
	// vision Script
	//step one: determine with a sphere collider if things are around us
	 void OnTriggerStay( Collider Other) {
		Vector3 MyPosition = transform.position;
		Vector3 MyVector = transform.forward;
		Vector3 TheirPosition = Other.transform.position;
		Vector3 ThierVector = TheirPosition - MyPosition;

		//step 2: is the object in front of this enemy

		float mag = Vector3.SqrMagnitude (MyVector) * Vector3.SqrMagnitude (ThierVector);
		//prevent devide by zero
		if (mag == 0f) {return;}

		float dotProd = Vector3.Dot (MyVector, ThierVector);
		bool isNegative = dotProd < 0f;
		dotProd = dotProd * dotProd;
		// square will eliminate negative values but we do still want to keep them
		if (isNegative) {dotProd *= -1;}
		float sqrAngle = Mathf.Rad2Deg * Mathf.Acos (dotProd / mag);
		bool IsInFront = sqrAngle < HalfConeSize;
		if (Other.gameObject.tag == "Player") {
			//print(sqrAngle + " " + Other.gameObject.name);

		}
				//step 3: is there anything infront of the object
		Debug.DrawLine(MyPosition, TheirPosition, IsInFront ? Color.green :Color.red);

		if (IsInFront) {
			
			// make sure that the layermask can pnly hit what we want
			int mask = 1 << LayerMask.NameToLayer ("Env");
			if (Physics.Linecast (MyPosition, TheirPosition, mask)) {
				//aiStates = patrolStates.Patrol;
			}
			if (!Physics.Linecast (MyPosition, TheirPosition, mask)) {
				if (Other.gameObject.tag == "Player") {
				//print ("Sensing Something " + Other.gameObject.name);
				lastSeen = Other.transform;
				//aiStates = patrolStates.Chase;
				}
			}
		} else {
			if (sqrAngle <= 90 && isNegative) {
				mover.Turn (-1);
				//print ("Test NonNEgatice");
			}
			if (sqrAngle <= 90 && !isNegative) {
				mover.Turn (1);
				//print ("Test NEgatice");
				//print (sqrAngle + " " + Other.gameObject.name);
			}
			//redundency
			if (sqrAngle > 90 && isNegative) {
				mover.Turn (-1);
			}
			if (sqrAngle > 90 && !isNegative) {
				mover.Turn (1);
			}
		}
	}


	void Flee () {
		if (Time.time >= fleeTimer) {
			// adding time to make sure timer is happening
			fleeTimer = Time.time + fleeDelay;
			/*if (pawn.health <= pawn.maxHealth) {
				pawn.health += pawn.regenAmount;
					
			}
			else {
				aiStates = patrolStates.Patrol;
			}

			*///mover.Turn(1);
		}
		// this is what the vector is from the player to the target
		Vector3 vectorToTarget = lastSeen.position - transform.position;
		// now we need to make it negative to move AWAY from the player
		Vector3 vectorAwayFromTarget = vectorToTarget * -1;
		// now we need to normalize it to make it so the magnitude is one
		vectorAwayFromTarget.Normalize();
		// now a normalized vector can use multiplication to set the lenght of the vector
		vectorAwayFromTarget *= pawn.fleeDistance;
		// now we can use the new vectors to find the space we want to move to, this will give a point away from the player
		Vector3 fleePosition = vectorAwayFromTarget + transform.position;
		//now to make them move
		//MovetowardsWIthVector(fleePosition);
		//Movetowards(fleePosition);
		//transform.Translate(fleePosition);
		mover.Move (-1);
	}











}
