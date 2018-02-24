using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { Idle, Walk, Jump, Fall }

public class ADVmove : NotouchStateMachine {

    public Transform AnimatedMesh;

    public float WalkSpeed;
    public float WalkAcceleration;
    public float JumpAcceleration;
    public float JumpHeight;
    public float Gravity;
    //direction player art is facing
    public Vector3 lookDirection { get; private set; }

    private NotouchStateMachine StateMachine;

    //current velocity
    private Vector3 _mDir;
    //Player States

	// Use this for initialization
	void Start ()
    {
        _mDir = Vector3.forward;

        //sets current state to idle on startup
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
