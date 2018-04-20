using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public Rigidbody PlayerRB;
    public float respawnBombtimer;
    public Transform bombrespawn;
    public MeshRenderer MeshComponent;
    public GameObject mygameobject;
    public Animator bombFlash;
    public bool boom;
    public float bombForce;
    public float bombHeight;

    public GameObject splat;
    public GameObject Player;

    private Camera cam;
    private float CurrentTimer;

    private bool reset = false;
    private bool isthrown = false;
    private bool throwButton = false;
    private Transform startingParent;
    private Rigidbody RB;

    void Awake()
    {
        cam = Camera.main;
        
        //CurrentTimer = respawnBombtimer;
        startingParent = transform.parent;



        //////////////////////////////////////////////////
        ////ignore collision with player to fix ball throw
        //////////////////////////////////////////////////
    }
    // Update is called once per frame
    void Update()
    {
        ResetBomb();

        if (Input.GetButtonUp("buttonThrow"))
        {


            if(!isthrown)
            {
                bombFlash.SetTrigger("startTimer");

                transform.parent = null;

                RB = mygameobject.AddComponent<Rigidbody>();
                //RB.velocity = new Vector3(RB.velocity.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight), PlayerRB.velocity.z * bombForce);
                RB.AddForce(Player.transform.up * (Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight)), ForceMode.Impulse);
                RB.AddForce(Player.transform.forward * bombForce, ForceMode.Impulse);
                RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
                RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
               
                isthrown = true;
            }
            else if(isthrown)
            {
                Debug.Log(" do nothing");
            }

        }
      

    }


    void ResetBomb()
    {
     
        if (boom && isthrown)
        {
            Instantiate(splat, mygameobject.transform.position, mygameobject.transform.rotation);
            DestroyObject(RB);
            MeshComponent.enabled = false;
            ResetValues();



        }
    }

    void ResetValues()
    {
        mygameobject.transform.position = bombrespawn.position;
        transform.parent = startingParent;
        respawnBombtimer = CurrentTimer;
        MeshComponent.enabled = true;
        reset = false;
        isthrown = false;
        boom = false;
    }

    void BombArm()
    {
        boom = true;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    collision.transform.tag = "Player";

    //}

}
