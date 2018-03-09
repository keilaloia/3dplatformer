using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxplate : MonoBehaviour {

    public Rigidbody Door;
    float Speed = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("yay");
            Door.velocity = transform.up * Speed;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
