using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour {

    public Vector3 HeightOffset;
    public Vector3 FeetOffset;
    [SerializeField]
    private float Angle;

    public float distance;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        RaycastHit Rhit;
        RaycastHit Fhit;


        Ray rDir = new Ray(transform.position + HeightOffset, transform.forward);
        Ray fDir = new Ray(transform.position + FeetOffset, transform.forward);

        
        Debug.DrawRay(transform.position + HeightOffset, transform.forward * distance, Color.black);
        Debug.DrawRay(transform.position + FeetOffset, transform.forward * distance, Color.magenta);

        Physics.Raycast(rDir, out Rhit, distance);

        if(Physics.Raycast(fDir, out Fhit, distance))
        {
            Angle = Vector3.Angle(Fhit.normal, transform.forward);
            //Angle = Vector3.Angle(Rhit.point, Fhit.point);
            Debug.Log(Angle);
        }
    }


}
