using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour {
	public TankData pawn;
	public List<Transform> waypoints;
	private int currentWaypoint = 0;
	public float closeEnough = 1.0f;
	public bool isPatroling;
	public bool isAdvancingWaypoints = true;
	public float avoidanceDistance;

	public enum patrolStates { Flee,Waypoint,Chase,Patrol}
	public patrolStates aiStates;

	public enum AvoidStates {normal, TurnToAvoid,MoveToAvoid }
	public AvoidStates avoidState;
	public  float avoidDuration = 1.0f;
	private float avoidStateTime;
	public TankMover mover;

	// Use this for initialization
	void Start () {
		mover = GetComponent<TankMover> ();

	}


	protected void idle () {
	// Do Nothing!
	}
	protected void Chase () {
		// TODO: Create Chase function
		Movetowards(GameManager.instance.player.pawn.mover.tf.position);
	}
	 protected void Waypoint () {
		// TODO: Create Waypoint function
	//	if (  ) {
			// Do nothing!
	//	} else {
			mover.Move(1);
		//}
	}
	 protected void Patrol () {
		// TODO: Create Patrol function

	}
	protected void Flee () {
		// TODO: Create a Chase function
	}
	protected void Movetowards(Vector3 target) {
		if (avoidState == AvoidStates.normal) {
			
		}
	}
		
	void Update () {
		if (aiStates == patrolStates.Waypoint) {
			Waypoint ();
		} else if (aiStates == patrolStates.Chase) {
			Chase ();
		}
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

		float dotProd = Vector3.Dot (MyVector, TheirPosition - MyPosition);
		bool isNegative = dotProd < 0f;
		dotProd = dotProd * dotProd;
		// square will eliminate negative values but we do still want to keep them
		if (isNegative) {dotProd *= -1;}
		float sqrAngle = Mathf.Rad2Deg * Mathf.Acos (dotProd / mag);
		bool IsInFront = sqrAngle < HalfConeSize;
		if (Other.gameObject.tag == "Player") {
			print(sqrAngle + " " + Other.gameObject.name);
		}
				//step 3: is there anything infront of the object
		Debug.DrawLine(MyPosition, TheirPosition, IsInFront ? Color.green :Color.red);
		if (IsInFront && Other.gameObject.tag == "Player") {
		// make sure that the layermask can pnly hit what we want
			int mask = 1 << LayerMask.NameToLayer("Env");
			if (!Physics.Linecast (MyPosition, TheirPosition, mask)) {
				print ("Sensing Something " + Other.gameObject.name);
				Chase ();
			}
		}
	}
}
