using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public GameObject Coin;
    int point;
    Score score;

	void Start ()
    {
        point = 1;
	}

    private void OnTriggerEnter(Collider other)
    {
        Score.score += point;

        DestroyObject(Coin);
    }


    void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 80); 
	}
}