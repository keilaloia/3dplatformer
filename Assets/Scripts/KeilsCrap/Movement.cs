using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineFreeLook))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float MaxwSpeed;
    public float ZerotoMax;
    public float MaxtoZero;
    public float gravityScale;
    public float JumpHeight;
    public float turnAnglePerSec;
    public float Rotation_Friction;
    public GameObject PlayerMesh;
   // public CinemachineFreeLook followCam;
   // public Camera main;


    private Rigidbody RB;
    private Vector3 mDir;
    private float AccelRatePerSec;
    private float decelRatePerSec;
    private float fVelocity;
    private CapsuleCollider Bound;



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
        //followCam = GetComponent<CinemachineFreeLook>();

        //acceleration equations
        AccelRatePerSec = MaxwSpeed / ZerotoMax;
        decelRatePerSec = -MaxwSpeed / MaxtoZero;
        fVelocity = 0f;
       
    }

    void FixedUpdate()
    {

        //Get Main camera in Use.
        Camera cam = Camera.main;


        float V = Input.GetAxis("LeftJoyY");
        float H = Input.GetAxis("LeftJoyX");

        //mDir = new Vector3( H,0.0f, V);
        mDir = ((cam.transform.right * H) + (cam.transform.forward * V));
        mDir.y = 0.0f;

        Turning(mDir.normalized);
        MoveFowardAccel(mDir.sqrMagnitude);
        Jumpstuff(Input.GetButtonDown("ControllerJump"));
      
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

    void Jumpstuff(bool jump)
    {
        if(jump && isGrounded)
        {
            RB.velocity = new Vector3 (RB.velocity.x, (Mathf.Sqrt(-2.0f * Physics.gravity.y * JumpHeight)),RB.velocity.z);
            Debug.Log("I jumped");

        }


    }
 
    void Turning(Vector3 Dir)
    {

        transform.forward = Vector3.RotateTowards(transform.forward, Dir, turnAnglePerSec * Time.deltaTime * Rotation_Friction, 0.0f);

    }



}
