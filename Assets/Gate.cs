using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public GameObject gate;

	void Start ()
    {
        gate.SetActive(true);	
	}

    private void OnTriggerEnter(Collider other)
    {
        gate.SetActive(false);
    }
    void Update () {
		
	}
}
