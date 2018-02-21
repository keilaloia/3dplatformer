using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

    public Rigidbody player;
    public int force = 20;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {  
            player.AddForce(0,force,0);
    }
  
	void Update ()
    {
		
	}
}
