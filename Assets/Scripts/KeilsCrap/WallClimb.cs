using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour {


    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    public float distance;
    public float cSpeed;

    [SerializeField]
    private bool Climbable = false;
    private float Angle;
    private float V;
    private float H;
    private Vector3 cDir;
    private Movement MoveScript;
    private Camera cam;
    private Rigidbody RB;
    void Awake()
    {
        cam = Camera.main;

        MoveScript = GetComponent<Movement>();
        RB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        V = Input.GetAxis("LeftJoyY");
        H = Input.GetAxis("LeftJoyX");
        cDir = (transform.right * H) + (transform.up * V);
        
        isclimable();

     

        
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

        }
        else
        {
            Climbable = false;
        }

        if(Climbable)
        {
            MoveScript.enabled = false;
            RB.velocity = cDir * cSpeed;
            RB.useGravity = false;

        }
        else
        {
            MoveScript.enabled = true;
            RB.useGravity = true;
        }


    }

    //void Cmovement(float input)
    //{
    //    cMove = transform.up * cVelocity;
    //    //cMove = transform.right * cVelocity;

    //    cMove.y = RB.velocity.y;
    //    if (input != 0)
    //    {
    //        //grab the forward velocity and accelerate it while grabbing the min value before max walk speed to clamp
    //        cVelocity += AccelRatePerSec * Time.deltaTime;
    //        cVelocity = Mathf.Min(cVelocity, MaxwSpeed);
    //        RB.velocity = cMove;

    //        //if(Climbable)
    //        //{
    //        //    transform.position += (Vector3.up * fVelocity) * Time.deltaTime;

    //        //   // transform.position += (Vector3.right * fVelocity) * Time.deltaTime;

    //        //}

    //    }
    //    else
    //    {
    //        //deccel and grab the max velocity making sure not to go negative
    //        cVelocity = Mathf.Max(cVelocity, 0);
    //        cVelocity += decelRatePerSec * Time.deltaTime;
    //        RB.velocity = cMove;

    //    }

    //}

}
