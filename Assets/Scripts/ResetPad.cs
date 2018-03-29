using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPad : MonoBehaviour {


    //public GameObject[] GoodBox;
    public Mother mother;
    public bool Again;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Again = true;
        }
    }

    void Update ()
    {
	    
	}
}
