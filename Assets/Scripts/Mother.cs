using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {

    
    public FloorPad[] GoodBox;
    public ResetPad[] RPad;
    public bool[] IsGreen;
    public Material[] material;
    public Renderer[] rend;
    public GameObject Nice;
    public GameObject[] remove;

    public bool IsFinished;

    

    void Start ()
    {

	}

    void DoOver()
    {
        rend[0].sharedMaterial = material[0];
        IsGreen[0] = false;
        DestroyObject(remove[0]);
        ////////////////////////////////
        rend[1].sharedMaterial = material[0];
        IsGreen[1] = false;
        DestroyObject(remove[1]);
        ////////////////////////////////
    }

    void OnSwitch()
    {
        Nice.SetActive(true);
    }


    void Update ()
    {
        if (GoodBox[0].IsGreen == true && GoodBox[0].IsBoxGood == true)
        {
            rend[0].sharedMaterial = material[1];
            IsGreen[0] = true;
        }

        if (GoodBox[1].IsGreen == true && GoodBox[1].IsBoxGood == true)
        {
            rend[1].sharedMaterial = material[1];
            IsGreen[1] = true;
        }


        //if (RPad[0].Again == true)
        //{
        //    DoOver();
        //}

        if (IsGreen[0] && IsGreen[1] == true)
        {
            IsFinished = true;
            OnSwitch();
        }
    }
}
