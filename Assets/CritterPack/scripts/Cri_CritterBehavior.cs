using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cri_CritterBehavior : MonoBehaviour {

	private int myState = 1; // state 0= just starts, 1=moves, 2=idle, 3=dead

	private float timeToChange=0;
	private bool justChangedStates=true;

	public float moveTime = 1;
	public float moveTimeRnd = 0.2f;
	private float actualMoveTime = 1;
	public float moveSpeed =1;
	public AnimationClip[] moveAnims;
	private AnimationClip actualMoveAnim;

	public float turnSpeed = 1;   //speed of turning
	public float maxTurnAngle = 30;		// maximum turn angle in one turn session, high for insects, low for larger animals
	private float targetTurnAngle = 0;  //actual turn angle
	private float actualTurnAngle = 0; // to track how close is the animal turning to its target turn angle
	public float turnTargetChange = 2;	// how often the animal changes its direction, low = zippy movement
	public float turnTargetChangeRnd = 0.5f;
	private float turnTargetChangeAct = 2;


	private bool turning=true;       //is the animal currently turning?
	private float actualTurnChange = 0;  // how close we are to changing the turn target

	public bool idles = true;
	public float idleTime = 1; 
	public float idleTimeRnd = 0.2f;
	private float targetIdleTime=2;
	private float actualIdleTime=0;

	public AnimationClip[] idleAnims;
	private AnimationClip actualIdleAnim;
	private Animation _animation;




	public float lifeTime = 10;
	public float timeToPerish=1;
	public AnimationClip[] deathAnims;
	private AnimationClip actualDeathAnim;




	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {

		//lifeTime -= Time.deltaTime;
		if (lifeTime < 0) {
			myState = 3;
			justChangedStates = true;
		}





		//****************** MOVING
		if (myState==1){
			
			if (justChangedStates == true){
				JustBeganMoving ();
				actualTurnChange = 0;
				justChangedStates = false;
				ChooseTurn ();
			}

			actualTurnChange += Time.deltaTime;
			if (actualTurnChange>turnTargetChangeAct){
				ChooseTurn ();
			}


			if (turning==true){
				if (targetTurnAngle < 0) {
					transform.Rotate (0, -turnSpeed * Time.deltaTime, 0);
					actualTurnAngle += -turnSpeed * Time.deltaTime;
					if (actualTurnAngle<targetTurnAngle) turning=false;
				}
				if (targetTurnAngle > 0) {
					transform.Rotate (0, turnSpeed * Time.deltaTime, 0);
					actualTurnAngle+=turnSpeed * Time.deltaTime;
					if (actualTurnAngle>targetTurnAngle) turning=false;

				}
			}





			transform.Translate(0, 0, moveSpeed*Time.deltaTime);


			if ((timeToChange>actualMoveTime) && idles==true){
				timeToChange=0;
				myState=2;
				justChangedStates = true;
				turning = false;
			}

					

		}

		//****************** IDLING
		if (myState==2){
			if (justChangedStates == true) {
				JustBeganIdling ();
				justChangedStates = false;
			}

			actualIdleTime += Time.deltaTime;
			if (actualIdleTime > targetIdleTime) {
				timeToChange=0;
				myState=1;
				justChangedStates = true;
			}

		}


		//****************** IF I AM DEAD
		if (myState==3){
			if (justChangedStates == true) {
				justBeganDying ();
				justChangedStates = false;
			}
		}


	 	timeToChange += Time.deltaTime;  


	}

	void JustBeganMoving(){     //sets the actual movetime, and the actual animation
		if (moveAnims.Length > 0) {
			
			actualMoveTime = moveTime + Random.Range (-moveTimeRnd, moveTimeRnd);
			actualMoveAnim = moveAnims [Mathf.RoundToInt (Random.Range (0, moveAnims.Length))];
			_animation.CrossFade (actualMoveAnim.name);
		}
	
	}

	void ChooseTurn(){
		turnTargetChangeAct = turnTargetChange + Random.Range (turnTargetChangeRnd, -turnTargetChangeRnd);
		targetTurnAngle=Random.Range(maxTurnAngle, -maxTurnAngle);
		actualTurnAngle = 0;
		actualTurnChange = 0;
		turning = true;
	}

	void JustBeganIdling(){
		if (idleAnims.Length > 0) {
			
			actualIdleAnim = idleAnims [Mathf.RoundToInt (Random.Range (0, idleAnims.Length))];
			_animation.CrossFade (actualIdleAnim.name);

		}

		targetIdleTime = idleTime + Random.Range (-idleTimeRnd, idleTimeRnd);
		actualIdleTime = 0;

	}

	void justBeganDying(){
		if (deathAnims.Length>0)
		{
		actualDeathAnim = deathAnims[Mathf.RoundToInt(Random.Range (0, deathAnims.Length))];
		_animation.CrossFade (actualDeathAnim.name);
		}

		Destroy (gameObject, timeToPerish);

	}



}
