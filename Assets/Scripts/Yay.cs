using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yay : MonoBehaviour {

    public GameObject Coin;
    public GameObject Nice;

	// Use this for initialization
	void Start ()
    {
		
	}

    void OnSwitch()
    {
        Nice.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnSwitch();
        DestroyObject(Coin);
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
