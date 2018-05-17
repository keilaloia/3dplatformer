using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EqualScoreCoin : MonoBehaviour {

    int score;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        score = scorecoin.scoreCoin;

        text.text = "Score: " + score + " /7";
    }
}
