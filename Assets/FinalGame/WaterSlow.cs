using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour {

    private Movement movesingleton;
    private float currentwalkspeed;

    void Start()
    {

        movesingleton = Movement.instance.GetComponent<Movement>();
        currentwalkspeed = movesingleton.MaxwSpeed;


    }

    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("derp");
        if (other.gameObject.layer == 10)
        {
            Debug.Log("entertrigger");
            movesingleton.MaxwSpeed = 5;
        }

    }
    void OnTriggerStay(Collider other)
    {

        //Debug.Log("derp");
        if (other.gameObject.layer == 10)
        {
            Debug.Log("Stay");
            movesingleton.MaxwSpeed = 3;
           

        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exittrigger");

        movesingleton.MaxwSpeed = currentwalkspeed;
    }
}
