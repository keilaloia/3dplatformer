using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject DeaDBug;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {

            Instantiate(DeaDBug, transform.position, transform.rotation);
            Destroy(col.gameObject);

        }

    }   
    
}
