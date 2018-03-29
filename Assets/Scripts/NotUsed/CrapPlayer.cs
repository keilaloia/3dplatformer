using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapPlayer : MonoBehaviour
{

	private Rigidbody _rb;
	private float _speed =  10.0f;
	private AnchorSingleton _Anchor;
	private Vector3 _Aoffset;

	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody>();
		_Anchor = AnchorSingleton.Singleton.GetComponent<AnchorSingleton>();
		_Aoffset = new Vector3(0,0,-5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		_rb.AddForce(movement * _speed);
        spawnAnchor();
	}


	void spawnAnchor()
	{
	    _Anchor.transform.position = transform.position + _Aoffset;
	}
}
