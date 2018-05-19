﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplayCanvas : MonoBehaviour {

    public static gameplayCanvas instance;
    
    public Bug_2_0[] monsters;
    public Text txtPages;
    public string pagesString;
    public int pagesTotal = 4;
    private int pagesFound = 0;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        updateCanvas();
    }

    public void updateCanvas()
    {
        pagesString = "Pages " + pagesFound.ToString() + "/" + pagesTotal.ToString();
        txtPages.text = pagesString;
    }

    public void findPage()
    {
        pagesFound++;
        updateCanvas();

        //win//
        if (pagesFound >= pagesTotal)
        {
            

            for (int n = 0; n < monsters.GetLength(0); n++)
            {
                monsters[n].death();
            }
        }
    }
}
