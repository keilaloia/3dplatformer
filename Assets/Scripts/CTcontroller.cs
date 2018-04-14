using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTcontroller : MonoBehaviour {


    public GameObject[] Trail;
    public GameObject Self;


    void Start()
    {
        Trail[0].SetActive(false);
        Trail[1].SetActive(false);
        Trail[2].SetActive(false);
        Trail[3].SetActive(false);
        Trail[4].SetActive(false);
        Trail[5].SetActive(false);
        Trail[6].SetActive(false);
        Trail[7].SetActive(false);
        Trail[8].SetActive(false);
        Trail[9].SetActive(false);
        Trail[10].SetActive(false);
        Trail[11].SetActive(false);
        Trail[12].SetActive(false);
        Trail[13].SetActive(false);
        Trail[14].SetActive(false);
        Trail[15].SetActive(false);
        Trail[16].SetActive(false);
        Trail[17].SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Trail[0].SetActive(true);
            Trail[1].SetActive(true);
            Trail[2].SetActive(true);
            Trail[3].SetActive(true);
            Trail[4].SetActive(true);
            Trail[5].SetActive(true);
            Trail[6].SetActive(true);
            Trail[7].SetActive(true);
            Trail[8].SetActive(true);
            Trail[9].SetActive(true);
            Trail[10].SetActive(true);
            Trail[11].SetActive(true);
            Trail[12].SetActive(true);
            Trail[13].SetActive(true);
            Trail[14].SetActive(true);
            Trail[15].SetActive(true);
            Trail[16].SetActive(true);
            Trail[17].SetActive(true);
            //////////////////////////
            Self.SetActive(false);
        }
    }


    void Update()
    {

	}
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 80);
    }

}
