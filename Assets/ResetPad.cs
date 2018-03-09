using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPad : MonoBehaviour {


    public GameObject[] GoodBox;
    public Mother mother;
    public GameObject[] remove;
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<FloorPad>().mother.rend[0].sharedMaterial = mother.material[0];
            mother.rend[0].sharedMaterial = mother.material[0];
            mother.IsGreen[0] = false;
            DestroyObject(remove[0]);
            ////////////////////////////////
            gameObject.GetComponent<FloorPad>().mother.rend[1].sharedMaterial = mother.material[0];
            mother.rend[1].sharedMaterial = mother.material[0];
            mother.IsGreen[1] = false;
            DestroyObject(remove[1]);
            ////////////////////////////////
        }
    }

    void Update ()
    {
	    
	}
}
