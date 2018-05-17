using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healone : MonoBehaviour
{
    private PlayerStats statsinstance;


    private void Start()
    {
        statsinstance = PlayerStats.instance.GetComponent<PlayerStats>();


    }
    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("derp");
        if (other.gameObject.layer == 10)
        {

            statsinstance.GainHealth();
            Destroy(gameObject);

        }

    }
}
