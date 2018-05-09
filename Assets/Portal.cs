using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log(" level load request for: " + name);

        Application.LoadLevel(name);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            LoadLevel("death");
        }

    }
}
