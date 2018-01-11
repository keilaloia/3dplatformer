using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapCaste : MonoBehaviour
{

	private Rigidbody rb;

	private RaycastHit hit;

	public float length;
	public Vector3 offset;
	private CameraSingleTon cams;

	private Vector3 fDist;
	// Use this for initialization
	void Start ()
	{
	   // offset = new Vector3(0, 1.5f, -5.0f);
		rb = GetComponent<Rigidbody>();
		cams = CameraSingleTon.instance.GetComponent<CameraSingleTon>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		caste();
		cams.transform.position = fDist;
		Debug.DrawLine(transform.position, transform.position + offset, Color.blue);
	}

	void caste()
	{
		if(Physics.Linecast(transform.position, transform.position + offset, out hit))
		{
			fDist = transform.position + offset;

		}
		else
		{
			fDist = transform.position + offset;
		}
	}
}
