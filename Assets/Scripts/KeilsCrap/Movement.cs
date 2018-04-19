using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CheckSlope))]
[RequireComponent(typeof(WallClimb))]

public class Movement : MonoBehaviour
{
    public float MaxwSpeed;
    public float ZerotoMax;
    public float MaxtoZero;
    public float JumpHeight;
    public float turnAnglePerSec;
    public float Rotation_Friction;
    public float AirDrag;
    public GameObject PlayerMesh;
    public Animator anim;
    public Transform childTransform;


    private Vector3 mDir;
    private Rigidbody RB;
    private Vector3 move;
    private float V;
    private float H;
    private float AccelRatePerSec;
    private float decelRatePerSec;
    private float fVelocity;
    private CapsuleCollider Bound;
    private Camera cam;
    private Vector3 Direction;

    //singleton creation
    private static Movement _Instance;
    public static Movement instance
    {
        get
        {
            return _Instance;
        }
    }



    public bool isGrounded
    {
        get
        {
            Vector3 startPoint = transform.position + (Vector3.down * Bound.bounds.extents.y * .9f);
            Vector3 endPoint = startPoint + (Vector3.down * Bound.bounds.extents.y * .2f);
            Debug.DrawLine(startPoint, endPoint, Color.red);
            return Physics.Raycast(startPoint, Vector3.down, Bound.bounds.extents.y * .2f);
        }
    }
    void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        else
            Destroy(gameObject);

        //Get Main camera in Use.
        cam = Camera.main;
        RB = GetComponent<Rigidbody>();
        //make constrain rb rotations on play
        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        Bound = GetComponent<CapsuleCollider>();

        //acceleration equations
        AccelRatePerSec = MaxwSpeed / ZerotoMax;
        decelRatePerSec = -MaxwSpeed / MaxtoZero;
        fVelocity = 5f;

        
    }
    void Update()
    {
       
        Jumpstuff(Input.GetButtonDown("ControllerJump"));

      



    }

    void FixedUpdate()
    {
        Direction = cam.transform.forward;
        



        //grab controller input and add to move direction 
        V = Input.GetAxis("LeftJoyY");
        H = Input.GetAxis("LeftJoyX");
        mDir = (cam.transform.right * H) + (Direction * V);

        //main methods making game work      
        Turning(mDir.normalized);
        MoveFowardAccel(mDir.magnitude);


        //set up animations
        anim.SetFloat("Speed", mDir.magnitude);
        Debug.Log(mDir.magnitude);
    }


    void MoveFowardAccel(float ForwardInput)
    {
        move = transform.forward * fVelocity;
        move.y = RB.velocity.y;

        if (ForwardInput != 0)
        {
            //grab the forward velocity and accelerate it while grabbing the min value before max walk speed to clamp
            fVelocity += AccelRatePerSec * Time.deltaTime;
            fVelocity = Mathf.Min(fVelocity, MaxwSpeed);  
            RB.velocity = move;

        }
        else
        {
            //deccel and grab the max velocity making sure not to go negative
            fVelocity += decelRatePerSec * Time.deltaTime;
            fVelocity = Mathf.Max(fVelocity, 0);
            RB.velocity = move;

        

        }

    }

    //absolute shit jump =D
    void Jumpstuff(bool bJump)
    {
        if (bJump && isGrounded)
        {
            // anim.SetTrigger("IsGrounded");
            anim.applyRootMotion = true;
            //transform.position = childTransform.position;
            //anim.SetBool("TouchGround", isGrounded);
            anim.SetTrigger("dojump");
            RB.velocity = new Vector3(RB.velocity.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * JumpHeight), RB.velocity.z);
            //RB.drag = AirDrag;
            Debug.Log("jumpcalled");
        }
        //only added for physics jump delete if necesarry, to improve add bool for bjump check
        else if (!isGrounded)
        {
            //anim.SetTrigger("IsGrounded");
            //anim.applyRootMotion = false;
            //anim.SetBool("TouchGround", false);

            RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
            // anim.SetTrigger("IsGrounded", isGrounded);

            //Debug.Log("being called");
        }

    }

    void Turning(Vector3 Dir)
    {
        //remove the y to allow for only horizontal plane of movement DO (NOT) REMOVE CODE!!!!!!!!!!!
        Dir.y -= Dir.y;

        //whats controlling the character turns. keep Rotation_Friction to 1 unless you fully understand it ask keil for details. basically variable to slow down the turns
        transform.forward = Vector3.RotateTowards(transform.forward, Dir, turnAnglePerSec * Time.deltaTime * Rotation_Friction, 0.0f);
    }

    public void EndRootMotion()
    {
        anim.applyRootMotion = false;
       // RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);

    }
    public void EndJump()
    {
            anim.SetTrigger("EndJump");

    }
}
