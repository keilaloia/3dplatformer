using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float MaxwSpeed;
    public float ZerotoMax;
    public float MaxtoZero;
    public float gFallmuliplier;
    public float lowJumpMultiplier;
    public float JumpHeight;
    public float turnAnglePerSec;
    public float Rotation_Friction;
    public GameObject PlayerMesh;
    public Animator anim;


    private Rigidbody RB;
    private Vector3 mDir;
    private float AccelRatePerSec;
    private float decelRatePerSec;
    private float fVelocity;
    private CapsuleCollider Bound;
    private float currentmass;


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
        RB = GetComponent<Rigidbody>();
        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Bound = GetComponent<CapsuleCollider>();

        //acceleration equations
        AccelRatePerSec = MaxwSpeed / ZerotoMax;
        decelRatePerSec = -MaxwSpeed / MaxtoZero;
        fVelocity = 0f;
        currentmass = RB.mass;
    }

    void FixedUpdate()
    {

        //Get Main camera in Use.
        Camera cam = Camera.main;


        float V = Input.GetAxis("LeftJoyY");
        float H = Input.GetAxis("LeftJoyX");

       
        mDir = ((cam.transform.right * H) + (cam.transform.forward * V));
        

        Turning(mDir.normalized);
        MoveFowardAccel(mDir.sqrMagnitude);
        Jumpstuff(Input.GetButtonDown("ControllerJump"));


        
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("Speed", mDir.magnitude);
    }

    void MoveFowardAccel(float ForwardInput)
    {
        if(ForwardInput != 0)
        {
            fVelocity += AccelRatePerSec * Time.deltaTime;
            fVelocity = Mathf.Min(fVelocity, MaxwSpeed);
            RB.velocity = transform.forward * fVelocity;
          
        }
        else
        {
            fVelocity = Mathf.Max(fVelocity, 0);
            fVelocity += decelRatePerSec * Time.deltaTime;
            RB.velocity = transform.forward * fVelocity;
          
        }

    }

    void Jumpstuff(bool bJump)
    {
        if (bJump&& isGrounded)
        {
            RB.velocity = new Vector3(RB.velocity.x, JumpHeight, RB.velocity.y);
            Debug.Log("jumpcalled");
        }
        else if (!isGrounded)
        {
            RB.AddForce(Physics.gravity * RB.mass * 10f, ForceMode.Force);
            Debug.Log("being called");
        }

    }

    void Turning(Vector3 Dir)
    {

        transform.forward = Vector3.RotateTowards(transform.forward, Dir, turnAnglePerSec * Time.deltaTime * Rotation_Friction, 0.0f);
       

    }



}
