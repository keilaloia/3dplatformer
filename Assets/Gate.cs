using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public GameObject gate;

	void Start ()
    {
	}

    private void OnCollisionEnter(Collision whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Player"))
        {
            gate.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 80);
    }

    void Update () {
		
	}
}
