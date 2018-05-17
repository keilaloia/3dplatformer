using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    private Movement movesingleton;
    public int health;
    // Use this for initialization
    void Start ()
    {
        movesingleton = Movement.instance.GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update ()
    {
		if(health <= 0)
        {
            Debug.Log("triggereddeath");
            DestroyObject(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entertriggered");
        if (other.gameObject.layer == 13 && movesingleton.IsAttacking)
        {

            health--;
            Debug.Log("worked");

        }

    }
}
