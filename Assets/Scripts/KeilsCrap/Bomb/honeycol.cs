using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeycol : MonoBehaviour {

    private Movement movesingleton;
    private float currentwalkspeed;
    void Awake()
    {
        movesingleton = Movement.instance.GetComponent<Movement>();
        currentwalkspeed = movesingleton.MaxwSpeed;  
        Debug.Log(currentwalkspeed);

    }
    void OnTriggerEnter(Collider other)
    {
      
        //Debug.Log("derp");
        if (other.tag == "Player")
        {
            movesingleton.MaxwSpeed = 5; 
        }

    }

    void OnTriggerExit(Collider other)
    {
        movesingleton.MaxwSpeed = currentwalkspeed;
    }
   
}
