using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class CameraRadius : MonoBehaviour
{
	public float radius;
	public Camera BaseCamera;
	
	//raycast
	private Rigidbody RB;
	private RaycastHit hit;

	public Transform shell;
	//camera spring arm
	private Vector3 targetdist;
	private Vector3 finalDist;
	private Vector3 velocity = Vector3.zero;
	private Transform cameraTransform;


	//draw circle
	[Range(0, 50)]
	public int segments = 50;
	[Range(0, 5)]
	public float xradius = 5;
	[Range(0, 5)]
	public float yradius = 5;
	LineRenderer line;
	// Use this for initialization
	void Start ()
	{
		RB = GetComponent<Rigidbody>();
		targetdist = new Vector3(0,0,-5f);

		//circle crap
		line= BaseCamera.gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount(segments + 1);
		line.useWorldSpace = false;


	}
	
	// Update is called once per frame
	void Update ()
	{
	   BaseCamera.transform.position = targetdist;

		LineRaycast();
		Debug.DrawRay(BaseCamera.transform.position, Vector3.down, Color.red);
	}

	void LateUpdate()
	{
		LineRaycast();
	   // BaseCamera.transform.position = Vector3.SmoothDamp(BaseCamera.transform.position, finalDist, ref velocity, .1f);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(BaseCamera.transform.position, radius);
		

	}

 

	void CreatePoints()
	{
		float x;
		float y;
		float z;
	   

		float angle = 20f;
		
		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

			line.SetPosition(i, new Vector3(x, hit.transform.position.y, z));
			
			angle += (360f / segments);
		}
	}

	void LineRaycast()
	{

		if (Physics.Raycast(shell.position, Vector3.down, out hit))
		{
			
			if (hit.point != null)
			{
				
				CreatePoints();

			}
		}

	}

	void springarmcast()
	{
		if (Physics.Linecast(transform.position, transform.position + targetdist, out hit))
		{
			finalDist = hit.point + (transform.position - hit.point).normalized * 1;
		}
		else
			finalDist = targetdist - transform.position;
	}
}
