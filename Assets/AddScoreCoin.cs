using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreCoin : MonoBehaviour {
    //public GameObject Coin;
    int point;
    scorecoin score;
    public AudioSource collect;

    void Start()
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
            scorecoin.scoreCoin += point;
            collect.Play();
            DestroyObject(this.gameObject);
        }
    }


    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 80);
    }
}
