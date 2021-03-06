﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public static Bomb instance;
    public Rigidbody PlayerRB;
    public float respawnBombtimer;
    public Transform bombrespawn;
    public MeshRenderer MeshComponent;
    public GameObject mygameobject;
    public Animator bombFlash;
    public bool boom;
    public float bombForce;
    public float bombHeight;
    public float playervelocitymultiplier = 1f;

    public GameObject splat;
    public GameObject Player;
    public Transform RightHand;
    public Animator Anim;


    private Camera cam;
    private float CurrentTimer;
    private bool reset = false;
    [SerializeField]
    private bool isthrown = false;
    private bool throwButton = false;
    private Transform startingParent;
    private Rigidbody RB;
    private Quaternion currentvalues;
   

    private Movement movesingleton;

    void Start()
    {
        Bomb.instance = this;
        
        //cam = Camera.main;
        movesingleton = Movement.instance.GetComponent<Movement>();
        //CurrentTimer = respawnBombtimer;

        startingParent = transform.parent;
        currentvalues = transform.rotation;
       
    }

    public void ResetParent()
    {
        transform.parent = null;
    }
   public void ParentHand()
   {
        transform.parent = RightHand;
        transform.position = RightHand.position;
   }
   public void ShouldThrow()
    {
        if (!isthrown)
        {
            ThrowBomb();
        }
        else if (isthrown)
        {
            Debug.Log("do nothing");
        }
    }

   public void ThrowBomb()
    {
        bombFlash.SetTrigger("startTimer");

        transform.parent = null;
        RB = mygameobject.AddComponent<Rigidbody>();
        RB.AddForce(Player.transform.up * (Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight)), ForceMode.Impulse  );
        RB.AddForce(Player.transform.forward * bombForce + Player.GetComponent<Rigidbody>().velocity * playervelocitymultiplier , ForceMode.Impulse);
        RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        isthrown = true;
    }

    // Update is called once per frame
    void Update()
    {
        ResetBomb();

    }

    public void HoneyDrop()
    {
        bombFlash.SetTrigger("startTimer");
        RB = mygameobject.AddComponent<Rigidbody>();
        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        transform.parent = null;     
        isthrown = true;

    }
    void ResetBomb()
    {
     
        if (boom && isthrown)
        {
            Instantiate(splat, mygameobject.transform.position, mygameobject.transform.rotation);
            DestroyObject(RB);
            MeshComponent.enabled = false;
           
            
            mygameobject.transform.position = bombrespawn.position;
            transform.parent = startingParent;
            respawnBombtimer = CurrentTimer;
            MeshComponent.enabled = true;
            reset = false;
            isthrown = false;
            boom = false;
            transform.rotation = currentvalues;
            

            movesingleton.BombThrown = false;

        }
    }


    //gonna be honest idk if this is actually doing anything but too scared too touch 
    public void BombArm()
    {
        boom = true;
        Debug.Log("boom");
    }

}
