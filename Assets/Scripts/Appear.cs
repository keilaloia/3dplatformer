using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour {

    public GameObject goal;


	void Start ()
    {
		
	}

    private void OnCollisionEnter(Collision whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Player"))
        {
            goal.SetActive(true);
        }
    }

    void Update ()
    {
		
	}
}
