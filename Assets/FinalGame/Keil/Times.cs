using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Times : MonoBehaviour {


    public float Timer;
    private float StartTime;

    public GameObject deletethis;
    public GameObject deletethisToo;


    private void Start()
    {
        StartTime = Timer;
    }
    // Update is called once per frame
    void Update ()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            Timer = StartTime;
            this.gameObject.SetActive(false);
            deletethis.SetActive(false);
            deletethisToo.SetActive(false);

        }
    }
}
