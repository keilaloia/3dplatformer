using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {


    public GameObject[] Coin;

	
	void Start ()
    {
        Coin[0].SetActive(false);
        Coin[1].SetActive(false);
        Coin[2].SetActive(false);
        Coin[3].SetActive(false);
        Coin[4].SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Coin[0].SetActive(true);
            Coin[1].SetActive(true);
            Coin[2].SetActive(true);
            Coin[3].SetActive(true);
            Coin[4].SetActive(true);

        }
    }

    void Update ()
    {
		

	}
}
