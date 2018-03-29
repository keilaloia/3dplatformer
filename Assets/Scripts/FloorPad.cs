using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPad : MonoBehaviour  {

    public bool IsBoxGood;
    public bool IsGreen;
    public Mother mother;
    //protected GameObject test;
    
    void Start ()
    {
        //mother.rend[0] = GetComponent<Renderer>();
        //mother.rend[0].enabled = true;
        //mother.rend[0].sharedMaterial = mother.material[0];
	}


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (IsBoxGood == true)
            {
                //mother.rend[0].sharedMaterial = mother.material[1];
                //mother.rend[1].sharedMaterial = mother.material[1];
                //DestroyObject(mother.test);
                IsGreen = true;
            }

        }
    }

    void Update ()
    {
		
	}
}
