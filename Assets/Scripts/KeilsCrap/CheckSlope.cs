using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour {

    public Vector3 HeightOffset;
    public float distance = 10;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        RaycastHit hit;

        Ray rDir = new Ray(transform.position, Vector3.forward);

        //Debug.DrawLine(transform.position, transform.position + Vector3.forward * distance, Color.red);

        Debug.DrawRay(transform.position, transform.forward * distance, Color.black);

    }


}
