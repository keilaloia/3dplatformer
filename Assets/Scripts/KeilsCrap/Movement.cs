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
    private float mag;
    private float currentTurn;
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
        float H = Input.GetAxis("RightJoyX");

        mag = new Vector2(V, H).magnitude;

        Vector3 wishMove = new Vector3(H, 0.0f, V);

        //RB.rotation = CurrentRotation;

        ////transform.rotation = Quaternion.Euler(0f, mag, 0);
        //Quaternion newRotation = Quaternion.LookRotation(transform.forward * mag, transform.up);

        //PlayerMesh.transform.rotation = Quaternion.Slerp(PlayerMesh.transform.rotation, newRotation, turnAnglePerSec * Time.deltaTime);

        // rotate towards the direction we're trying to move in
        transform.forward = Vector3.RotateTowards(transform.forward,
                                                  wishMove.normalized,
                                                  Mathf.Deg2Rad * turnAnglePerSec * Time.deltaTime,
                                                  0.0f);


        //transform.Rotate(0, fVelocity * mag * turnAnglePerSec * Time.deltaTime, 0);
        MoveFowardAccel(V);
        //currentTurn = turnAnglePerSec * Time.deltaTime * mag;
       
       // RB.rotation = Quaternion.Euler(RB.rotation.eulerAngles + new Vector3(0, currentTurn, 0));
        Jumpstuff(Input.GetButtonDown("ControllerJump"));
        Debug.Log(mag);

      

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

}
