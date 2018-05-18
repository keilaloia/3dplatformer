using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scorecoin : MonoBehaviour {


    public static int scoreCoin;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        scoreCoin = 0;
    }

    void Update()
    {
        text.text = "Score: " + scoreCoin + " / 7";
    }
}
