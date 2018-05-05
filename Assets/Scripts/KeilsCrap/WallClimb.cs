using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour {


    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    public float distance;
    public float cSpeed;
    public MeshCollider verticalmesh;
    public Animator ThisAnim;

    public float JumpHeight;
    //public Transform clubholster;
    //public Transform club;
    //private Transform handtransform;
    private bool isjump;

    [SerializeField]
    private bool Climbable = false;
    [SerializeField]
    private float Angle;
    [SerializeField]
    private float stepAngle;

    private float V;
    private float H;
    private Vector3 cDir;
    private Vector2 upDir;
    private Vector2 HoDir;
    private Movement MoveScript;
    private Camera cam;
    private Rigidbody RB;
    private Vector3 pos;
    [SerializeField]
    private float betweenangle;
    void Awake()
    {
        cam = Camera.main;

        MoveScript = GetComponent<Movement>();
        RB = GetComponent<Rigidbody>();
        //handtransform = club.transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        V = Input.GetAxis("LeftJoyY");
        H = Input.GetAxis("LeftJoyX");

        

        cDir = (transform.right * H) + (transform.up * V);

        isclimable(cDir);

        Jumpstuff(Input.GetButtonDown("ControllerJump"));

        ThisAnim.SetBool("isClimbing", Climbable);

        

        
    }

    void isclimable(Vector3 move)
    {

      

        RaycastHit Rhit;
        RaycastHit Fhit;

        Ray rDir = new Ray(transform.position + HeightOffset, transform.forward);
        Ray fDir = new Ray(transform.position + FeetOffset, transform.forward);


        Debug.DrawRay(transform.position + HeightOffset, transform.forward * distance, Color.black);
        Debug.DrawRay(transform.position + FeetOffset, transform.forward * distance, Color.magenta);

        //make an if statement for stepoffset
        Physics.Raycast(rDir, out Rhit, distance);       

        if (Physics.Raycast(fDir, out Fhit, distance))
        {
            Angle = Vector3.Angle(Fhit.normal, transform.forward);
            //Angle = Vector3.Angle(Rhit.point, Fhit.point);
            if (/*Angle > 150f && */Fhit.collider.gameObject.layer == 8)
            {
                Climbable = true;
            }
  
        }
        else
        {
            Climbable = false;
        }

        if(Climbable && !isjump)
        {
            //core gameplay code section for climbing
            MoveScript.enabled = false;

            //club.transform.parent = clubholster;

            //what makes the clamp work
    

            //keeps rotation from falling off
           
                pos = transform.position;
                Bounds tmpB = verticalmesh.bounds;
                pos = tmpB.ClosestPoint(pos);
                transform.position = pos;


                RB.velocity = move * cSpeed;
                RB.useGravity = false;
            /////////////////////////////////////////////////////////////////////
               // transform.eulerAngles = verticalmesh.transform.eulerAngles;
                Mathf.Clamp( verticalmesh.transform.eulerAngles.y , -150f, -180f);
            
       

        }
        else
        {
            MoveScript.enabled = true;
            RB.useGravity = true;
            //club.transform.parent = handtransform;
        }


    }


    void Jumpstuff(bool bJump)
    {
        if (bJump && Climbable)
        {
            isjump = true;
            ThisAnim.applyRootMotion = true;
            //transform.position = childTransform.position;
            //anim.SetBool("TouchGround", isGrounded);
            ThisAnim.SetTrigger("dojump");
            // RB.velocity = new Vector3(RB.velocity.x, -Mathf.Sqrt(-2.0f * Physics.gravity.y * JumpHeight), RB.velocity.z);
            RB.AddForceAtPosition(-transform.forward * 500f, transform.position, ForceMode.Impulse);
            //RB.drag = AirDrag;
            Debug.Log("jumpcalled");
        }
        //only added for physics jump delete if necesarry, to improve add bool for bjump check
        else if (!Climbable)
        {
            isjump = false;
            RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
            
        }

    }

}
