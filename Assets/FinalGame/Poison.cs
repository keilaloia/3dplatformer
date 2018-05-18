using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour {

    private Movement movesingleton;
    private PlayerStats statsinstance;
    private float currentwalkspeed;
    private float currentTimer;
    private float Timer = 3f;

    private bool inPoison = false;
    void Start()
    {

        movesingleton = Movement.instance.GetComponent<Movement>();

        statsinstance = PlayerStats.instance.GetComponent<PlayerStats>();
        currentwalkspeed = movesingleton.MaxwSpeed;
        currentTimer = Timer;

    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            if(inPoison)
            {
                losehealth();

            }
           
        }
    }
    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("derp");
        if (other.gameObject.layer == 10)
        {
            Debug.Log("entertrigger");
            movesingleton.MaxwSpeed = 3;
            inPoison = true;

        }

    }

    void OnTriggerStay(Collider other)
    {

        //Debug.Log("derp");
        if (other.gameObject.layer == 10)
        {
            Debug.Log("Stay");
            movesingleton.MaxwSpeed = 3;
            inPoison = true;

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exittrigger");

        movesingleton.MaxwSpeed = currentwalkspeed;
        Timer = currentTimer;

        inPoison = false;
    }

    void losehealth()
    {
        Timer = currentTimer;      
        statsinstance.LoseHealth();
    }
}
