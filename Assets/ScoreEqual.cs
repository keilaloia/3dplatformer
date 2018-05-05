using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreEqual : MonoBehaviour {

    int score;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        score = Score.score;

        text.text = "Score: " + score + " /100";
    }
}
