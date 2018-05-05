using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public GameObject Coin;
    int point;
    Score score;
    public AudioSource collect;


    void Start ()
    {
        point = 1;
	}
    //private void OnCollisionEnter(Collision whatHitMe)
    //{
    //    if (whatHitMe.gameObject.CompareTag("Player"))
    //    {
    //        Score.score += point;

    //        DestroyObject(Coin);
    //    }

    //}
    private void OnTriggerEnter(Collider whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Player"))
        {
            Score.score += point;
            collect.Play();
            DestroyObject(Coin);
        }
    }


    void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 80); 
	}
}