using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Camera rumble;

    private Movement movesingleton;
    private bool triggered;
    
    // Use this for initialization
    void Start () {
        movesingleton = Movement.instance.GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update () {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 && Input.GetButton("ControllerAttack"))
        {
            triggered = true;

            Debug.Log("hit");
        }
       
    }
}
