using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CheckSlope))]
public class Movement : MonoBehaviour
{
    public float MaxwSpeed;
    public float ZerotoMax;
    public float MaxtoZero;
    public float JumpHeight;
    public float turnAnglePerSec;
    public float Rotation_Friction;
    public GameObject PlayerMesh;
    public Animator anim;
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

    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    public float distance;

    private bool Climbable;
    private float Angle;
    private Vector3 Direction;

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

        //Get Main camera in Use.
        cam = Camera.main;

        RB = GetComponent<Rigidbody>();
        //make constrain rb rotations on play
        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        Bound = GetComponent<CapsuleCollider>();

        //acceleration equations
        AccelRatePerSec = MaxwSpeed / ZerotoMax;
        decelRatePerSec = -MaxwSpeed / MaxtoZero;
        fVelocity = 0f;

        
    }

    void FixedUpdate()
    {
        Direction = cam.transform.forward;



        //grab controller input and add to move direction 
        V = Input.GetAxis("LeftJoyY");
        H = Input.GetAxis("LeftJoyX");
        mDir = (cam.transform.right * H) + (Direction * V);
        isclimable();

        //main methods making game work
        Turning(mDir.normalized);  
        MoveFowardAccel(mDir.magnitude);
        Jumpstuff(Input.GetButtonDown("ControllerJump"));





        //set up animations
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("Speed", mDir.magnitude);
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

            if(Climbable)
            {
                transform.position += (Vector3.up * fVelocity) * Time.deltaTime;
               // transform.position += (Vector3.right * fVelocity) * Time.deltaTime;

            }



        }
        else
        {
            //deccel and grab the max velocity making sure not to go negative
            fVelocity = Mathf.Max(fVelocity, 0);
            fVelocity += decelRatePerSec * Time.deltaTime;
            RB.velocity = move;

        }

    }

    //absolute shit jump =D
    void Jumpstuff(bool bJump)
    {
        if (bJump && isGrounded)
        {
            RB.velocity = new Vector3(RB.velocity.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * JumpHeight), RB.velocity.z);
            Debug.Log("jumpcalled");
        }
        //only added for physics jump delete if necesarry, to improve add bool for bjump check
        else if (!isGrounded)
        {
            RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
            Debug.Log("being called");
        }

    }

    void Turning(Vector3 Dir)
    {
        //remove the y to allow for only horizontal plane of movement DO NOT REMOVE CODE!!!!!!!!!!!
        Dir.y -= Dir.y;

        //whats controlling the character turns. keep Rotation_Friction to 1 unless you fully understand it ask keil for details. basically variable to slow down the turns
        transform.forward = Vector3.RotateTowards(transform.forward, Dir, turnAnglePerSec * Time.deltaTime * Rotation_Friction, 0.0f);
       

    }

    void isclimable()
    {
        RaycastHit Rhit;
        RaycastHit Fhit;

        Ray rDir = new Ray(transform.position + HeightOffset, transform.forward);
        Ray fDir = new Ray(transform.position + FeetOffset, transform.forward);


        Debug.DrawRay(transform.position + HeightOffset, transform.forward * distance, Color.black);
        Debug.DrawRay(transform.position + FeetOffset, transform.forward * distance, Color.magenta);

        Physics.Raycast(rDir, out Rhit, distance);

        if (Physics.Raycast(fDir, out Fhit, distance))
        {
            Angle = Vector3.Angle(Fhit.normal, transform.forward);
            //Angle = Vector3.Angle(Rhit.point, Fhit.point);
            if (Angle > 150f && Fhit.collider.gameObject.layer == 8)
            {
                Climbable = true;
                

            }
            else
            {
                Climbable = false;
            }

            Debug.Log(Climbable);
           
        }

    }




}
