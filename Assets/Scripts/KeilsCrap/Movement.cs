using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject PlayerMesh;

    private Rigidbody RB;
    private Vector3 mDir;
    private Vector3 PrevmDir;
    private float AccelRatePerSec;
    private float decelRatePerSec;
    private float fVelocity;
    private Vector3 mag;
    private CapsuleCollider Bound;
    //private Quaternion CurrentRotation;
    //private Quaternion ProspectRotation;



    private Vector3 prevDir;
    private Vector3 curDir;
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
        //currentTurn = 0f;

       
    }

    void FixedUpdate()
    {
        float V = Input.GetAxis("LeftJoyY");
        float H = Input.GetAxis("LeftJoyX");

        mag = new Vector3( H,0.0f, V);
        Debug.Log(mag);



        //// rotate towards the direction we're trying to move in
        //if (mag.magnitude != 0.0f)
        //{
        //    transform.forward = Vector3.RotateTowards(transform.forward,
        //                                          mag,
        //                                          Mathf.Deg2Rad * turnAnglePerSec * Time.deltaTime,

        //                                          0.0f);

        //}

        //Vector3 finalPosition = RB.position + (transform.forward * mag.magnitude * 10 * Time.deltaTime);
        //RB.MovePosition(finalPosition);

        MoveFowardAccel(V);

        //if()
      
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
        //else if (!isGrounded)
        //{
        //    RB.AddForce(Physics.gravity * RB.mass * 3f);
        //    Debug.Log("being called");
        //}

    }
 
    //void ApplyExtraTurnRotation()
    //{
    //    // help the character turn faster (this is in addition to root rotation in the animation)
    //    float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
    //    transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    //}

    void Turning(float vInput, float hInput, Vector3 Axis)
    {
        Vector3 currentForward;
        currentForward = transform.forward * vInput;

        //Axis = new Vector3(hInput, 0, currentForward);
        
        

        

    }

}
