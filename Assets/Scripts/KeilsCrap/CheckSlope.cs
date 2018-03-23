using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckSlope : MonoBehaviour {


    [Header("Results")]
    [SerializeField]
    private float GroundSlopeAngle = 0f;
    [SerializeField]
    private Vector3 GroundSlopeDir = Vector3.zero;

    [Header("Settings")]
    public bool showDebug = false;
    public Vector3 rayOriginOffset1 = new Vector3(-0.2f, 0f, 0.16f);
    public Vector3 rayOriginOffset2 = new Vector3(0.2f, 0f, -0.16f);
    public float distance;
    public float SphereOffSet;
    public float SphereRadius;
    public float SphereCastDistance;
    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    public LayerMask Emask;
 



    private float Angle;
    private float raycastLength = 0.75f;
    private Movement MoveScript;
    
    private Rigidbody RB;
    //sphere start point
    private Vector3 sphereSP;
    private Vector3 GizmoSphere;

	// Use this for initialization
	void Awake ()
    {
        RB = GetComponent<Rigidbody>();
        MoveScript = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        
       
        sphereSP = new Vector3(transform.position.x, transform.position.y - SphereOffSet, transform.position.z);
        SphereCast(sphereSP);
        isclimable();

        
    }

    

    void SphereCast(Vector3 Origin)
    {
        RaycastHit hit;

        //spherecast
        if(Physics.SphereCast(Origin, SphereRadius, -transform.up, out hit, Emask))
        {
            
            GroundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            Vector3 temp = Vector3.Cross(hit.normal, Vector3.down);
            GroundSlopeDir = Vector3.Cross(temp, hit.normal);

           
        }

        RaycastHit slopeHit1;
        RaycastHit slopeHit2;

        //First raycast
        if(Physics.Raycast(Origin + rayOriginOffset1, Vector3.down, out slopeHit1, raycastLength ))
        {
            if(showDebug)
            {
                Debug.DrawLine(Origin + rayOriginOffset1, slopeHit1.point, Color.magenta);
            }
            //angle of slope on hit normal
            float angleOne = Vector3.Angle(slopeHit1.normal, Vector3.up);
            
            //Second raycast
            if(Physics.Raycast(Origin + rayOriginOffset2, Vector3.down, out slopeHit2, raycastLength))
            {
                if(showDebug)
                {
                    Debug.DrawLine(Origin + rayOriginOffset2, slopeHit2.point, Color.magenta);
                }
                //get angle of slope of 2 angles
                float angleTwo = Vector3.Angle(slopeHit2.normal, Vector3.up);
                //3 collision points: take the median by sorting array and grabbing middle
                float[] tempArray = new float[] { GroundSlopeAngle, angleOne, angleTwo };
                Array.Sort(tempArray);
                GroundSlopeAngle = tempArray[1];
            }
            else
            {
                //2 collision points (sphere and first raycast): average the two
                float average = (GroundSlopeAngle + angleOne) / 2;
                GroundSlopeAngle = average;
            }
                    
        }
       
        
    }
    void OnDrawGizmosSelected()
    {
        if(showDebug)
        {
            GizmoSphere = new Vector3(transform.position.x, transform.position.y - SphereOffSet, transform.position.z);

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(GizmoSphere, SphereRadius);
        }
     
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
                transform.forward = transform.up;
                Debug.Log("climbable");
            }
           
            Debug.Log(Angle);
        }
    }

}
