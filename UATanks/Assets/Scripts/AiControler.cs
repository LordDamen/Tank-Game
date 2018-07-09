using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour {
	private TankData pawn;
	private TankMover mover;
	private TankShooter shoot;
	private int currentWaypoint = 0;
	public float closeEnough = 1.0f;
	public enum patrolStates { Flee,Waypoint,Chase,Patrol,Shoot};
	public patrolStates aiStates;
	public Transform lastSeen;
	private float fleeTimer;
	public float fleeDelay;
	private float fireDelay;
	public float patrolTimer;
	int PlayerMask;
	public List<GameObject> Waypoints;
	// Use this for initialization
	void Start () {
		// get requried compoents
		mover = GetComponent<TankMover> ();
		pawn = GetComponent<TankData> ();
		shoot = GetComponent<TankShooter> ();

	}
	void Update () {
		//if the state is one then call that function
		if (aiStates == patrolStates.Flee) {
			Flee ();
		}
		if (aiStates == patrolStates.Waypoint) {
			Waypoint ();
		}
		if (aiStates == patrolStates.Chase) {
			Chase ();
		}
		if (aiStates == patrolStates.Patrol) {
			Patrol ();
		}
		if (aiStates == patrolStates.Shoot) {
			Shoot (lastSeen);
		}
		if (pawn.health <= pawn.retreatHealth) {
			aiStates = patrolStates.Flee;
		}

	}
	protected void Shoot (Transform target) {
		transform.LookAt (target);
		shoot.Fire ();
		if (!Physics.Linecast(transform.position,target.position,PlayerMask)) {
			aiStates = patrolStates.Chase;
		}
	}
	protected void Chase () {
		//the Enemy will move towards the last seen location of the player
		mover.Move (1);
		Movetowards(lastSeen);
		if (Vector3.Distance (transform.position, lastSeen.position) <= closeEnough) {
			patrolTimer = Time.time + pawn.patrolDelay;
			aiStates = patrolStates.Patrol;
		}
	}
	 protected void Waypoint () {
		//if the waypoint is close enough then turn and tick up the next waypoint
		if ( Vector3.Distance(Waypoints[currentWaypoint].transform.position,transform.position ) >= closeEnough) {
			//this is the turn inside of the mover
			mover.Turn (1);
			//this is setting where we are pointed at to the next waypoint
			Movetowards(Waypoints[currentWaypoint].transform);
			//this checks if it is close enough and then ticks the waypoint up
			if (Vector3.Distance (Waypoints[currentWaypoint].transform.position, transform.position) < closeEnough) {
				currentWaypoint++;
				// if the waypoint is at the end set it back to the beginning
				if (currentWaypoint == 4) {
					currentWaypoint = 0;
				}
			}
		} 
	}
	 protected void Patrol () {
		// DO nothing this is innate inside of the vision script
		mover.Move(1);
		if (patrolTimer <= Time.time) {
			aiStates = patrolStates.Waypoint;
		}
	}
	// this is the main movement command for the enemy
	protected void Movetowards(Transform target) {
		//we just look at the target then move forward
		transform.LookAt (target.position);
		// this just moves it forward after looking at the target
		mover.Move (1);
	}
	void Flee () {
		if (Time.time >= fleeTimer) {
			// adding time to make sure timer is happening
			fleeTimer = Time.time + fleeDelay;
		}
		else {
			aiStates = patrolStates.Patrol;
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
		// this is just a placeholder because i coudln't figure it out
		//TODO fix the flee script
		mover.Move (-1);
	}



	//this is the visision script below, it took time and effort to make it work correctly
	[SerializeField] private float HalfConeSize = 45f;
	// vision Script
	//step one: determine with a sphere collider if things are around us
	 void OnTriggerStay( Collider Other) {
		// these are the necessary locations for vision
		Vector3 MyPosition = transform.position;
		Vector3 MyVector = transform.forward;
		Vector3 TheirPosition = Other.transform.position;
		Vector3 ThierVector = TheirPosition - MyPosition;
		//step 2: is the object in front of this enemy
		//this part just checks for ifsomething is in front of it
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
		}
		//step 3: is there anything infront of the object
		Debug.DrawLine(MyPosition, TheirPosition, IsInFront ? Color.green :Color.red);
		if (IsInFront) {
			// make sure that the layermask can pnly hit what we want
			int mask = 1 << LayerMask.NameToLayer ("Env");
			PlayerMask = 1 << LayerMask.NameToLayer ("player");
			if (Physics.Linecast (MyPosition, TheirPosition, mask)){
				
			}
			if (!Physics.Linecast (MyPosition, TheirPosition, mask)) {
				if (Other.gameObject.tag == "Player") {
					//this sets the players last seen location into a variable that the enemy can seek for
					lastSeen = Other.transform;
					aiStates = patrolStates.Shoot;
				}
			}else {
				// this is how the tanks move
				if (sqrAngle <= 90 && isNegative) {
					mover.Turn (-1);
				}
				if (sqrAngle <= 90 && !isNegative) {
					mover.Turn (1);
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
	}

}
