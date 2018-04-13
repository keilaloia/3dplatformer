using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


    public float respawnBombtimer;
    public Transform bombrespawn;
    public MeshRenderer MeshComponent;
    public GameObject mygameobject;
    public Animator bombFlash;
    public bool boom;
    public float bombForce;
    public float bombHeight;
    public GameObject splat;

    private Camera cam;
    private float CurrentTimer;
    private bool startTimer = false;
    private Transform startingParent;
    private Rigidbody RB;

    void Awake()
    {
        cam = Camera.main;
        RB = mygameobject.AddComponent<Rigidbody>();

        CurrentTimer = respawnBombtimer;
        startingParent = transform.parent;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ResetBomb();
            Timer();

        if (startTimer)
        {
            startTimer = false;
            
            mygameobject.transform.position = bombrespawn.position;
            RB.isKinematic = true;

            MeshComponent.enabled = true;


        }


        if (Input.GetButtonDown("buttonThrow"))
        {
            bombFlash.SetTrigger("startTimer");
            Debug.Log("howdy");
        }
        else if(Input.GetButtonUp("buttonThrow"))
        {

            transform.parent = null;
            RB.isKinematic = false;
            //RB.velocity = new Vector3(RB.velocity.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight), playerrb.velocity.z * bombForce);
            RB.AddForce(cam.transform.up * (Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight)),ForceMode.Impulse);
            RB.AddForce(cam.transform.forward * bombForce, ForceMode.Impulse);
            RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

            Debug.Log("throw");
        }
        Debug.Log(respawnBombtimer);


    }


    void ResetBomb()
    {
     
        if (boom)
        {
            Instantiate(splat, mygameobject.transform.position, mygameobject.transform.rotation);
            MeshComponent.enabled = false;
            startTimer = true;
            transform.parent = startingParent;
            respawnBombtimer = CurrentTimer;

        }


        ////if (startTimer)
        ////{
        ////    respawnBombtimer = CurrentTimer;          
        ////}

        //if(startTimer && respawnBombtimer <= 0)
        //{
        //    //reset bomb back to root bone
        //    mygameobject.transform.position = bombrespawn.position;
        //    mygameobject.SetActive(true);

        //    //boom = false;
        //    startTimer = false;
        //    Debug.Log("called");
        //}
    }
    void Timer()
    {
        respawnBombtimer -= Time.deltaTime;

        if (respawnBombtimer <= 0)
        {
            respawnBombtimer = CurrentTimer;
        }
    }

}
