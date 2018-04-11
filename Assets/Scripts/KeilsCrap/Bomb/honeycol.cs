using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeycol : MonoBehaviour {

    public float movedepricator;
    void OnParticleCollision(GameObject other)
    {
       // Rigidbody body = other.rigidbody;
       // if(body)
        //{
          //  body.velocity = new Vector3(body.velocity.x * movedepricator, body.velocity.y * movedepricator, body.velocity.z * movedepricator)
        //}
        Debug.Log("derp");
       
    }
   
}
