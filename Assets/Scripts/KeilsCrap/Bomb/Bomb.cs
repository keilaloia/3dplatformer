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

    public Transform RightHand;

    public Animator Anim;
    public Animation throwbomb;


    private Camera cam;
    private float CurrentTimer;

    private bool reset = false;
    private bool isthrown = false;
    private bool throwButton = false;
    private Transform startingParent;
    private Rigidbody RB;

    private Movement movesingleton;


    void Awake()
    {
        //cam = Camera.main;
        //movesingleton = Movement.instance.GetComponent<Movement>();

        throwbomb = GetComponent<Animation>();
        //CurrentTimer = respawnBombtimer;
        startingParent = transform.parent;



        //////////////////////////////////////////////////
        ////bomb must lose its parent at end of animation
        //////////////////////////////////////////////////
        ////current problem is that i cannot refrence the end of an animation to set up a bool or animation event because it is attached to my player
        //// adding in a singleton to work as an intermediary ended up breaking the script and cause the bomb throwing in general not to trigger
        //// this is the closest ive gotten it to work its janky as all hell
        //////////////////////////////////////////////////
    }
    // Update is called once per frame
    void Update()
    {
        ResetBomb();
        //EndAnim();
        if (Input.GetButtonDown("buttonThrow"))
        {
           
            if(isthrown)
            {
                Debug.Log("do nothing");
                
            }
            else if(!isthrown)
            {
                Debug.Log("animationtriggered");
                Anim.SetTrigger("DoThrow");

                transform.parent = RightHand;

                if (throwbomb.IsPlaying("Throw") == false)
                {
                    Anim.SetTrigger("EndThrow");
                    Debug.Log("itworked");
                }


            }
           
        }

       

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

    //void EndAnim()
    //{
    //    Debug.Log("called");
    //    if(movesingleton.ThrowEnded == true)
    //    {
    //        transform.parent = null;
    //        //movesingleton.ThrowEnded 
    //    }
    //}

}
