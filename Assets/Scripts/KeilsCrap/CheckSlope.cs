using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour {

    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    public LayerMask Emask;
    public float distance;
    public float SphereOffSet;
    public float SphereRadius;
    public float SphereCastDistance;


    [SerializeField]
    private float Angle;
    [SerializeField]
    private float GroundSlopeAngle;
    [SerializeField]
    private float GroundSlopeDir;
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
    }


    void SphereCast(Vector3 Origin)
    {
        RaycastHit hit;

        //spherecast
        if(Physics.SphereCast(Origin, SphereRadius, -transform.up, out hit, Emask))
        {
            
            GroundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            Vector3 temp = Vector3.Cross(hit.normal, Vector3.down);
            GroundSlopeDir = Vector3.Angle(temp, hit.normal);

            Debug.Log(temp);
        }
    }
    void OnDrawGizmosSelected()
    {
        GizmoSphere = new Vector3(transform.position.x, transform.position.y - SphereOffSet, transform.position.z);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(GizmoSphere, SphereRadius);
    }

    void possibleJunkCode()
    {
        //RaycastHit Rhit;
        //RaycastHit Fhit;

        //Ray rDir = new Ray(transform.position + HeightOffset, transform.forward);
        //Ray fDir = new Ray(transform.position + FeetOffset, transform.forward);


        //Debug.DrawRay(transform.position + HeightOffset, transform.forward * distance, Color.black);
        //Debug.DrawRay(transform.position + FeetOffset, transform.forward * distance, Color.magenta);

        //Physics.Raycast(rDir, out Rhit, distance);

        //if(Physics.Raycast(fDir, out Fhit, distance))
        //{
        //    Angle = Vector3.Angle(Fhit.normal, transform.forward);
        //    //Angle = Vector3.Angle(Rhit.point, Fhit.point);
        //    if(Angle > 150f && Fhit.collider.gameObject.layer == 8)
        //    {
        //        Debug.Log("climbable");
        //    }
        //    if(Angle > 130 && Fhit.collider.gameObject.layer != 8)
        //    {

        //        RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration); 
        //    }
        //    Debug.Log(Angle);
        //}
    }

}
