using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour {

    private Movement movesingleton;
    private float currentwalkspeed;
    private float currentTimer;
    private float Timer = 5f;
    
    void Awake()
    {
       
        movesingleton = Movement.instance.GetComponent<Movement>();
        currentwalkspeed = movesingleton.MaxwSpeed;
        currentTimer = Timer;

    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {

            DestroyObject(this.gameObject);
            movesingleton.MaxwSpeed = currentwalkspeed;
            
            Debug.Log("destroy");
        }
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
