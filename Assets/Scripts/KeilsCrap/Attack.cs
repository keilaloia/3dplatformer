using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private Movement movesingleton;

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
            Debug.Log("hit");
        }
    }
}
