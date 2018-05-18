using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {

    
    public FloorPad[] GoodBox;
    public ResetPad[] RPad;
    public bool[] IsGreen;
    public Material[] material;
    public Renderer[] rend;
    public GameObject MoveP;

    public GameObject[] remove;

    public bool IsFinished;

    

    void Start ()
    {

	}

    void DoOver()
    {
        ////////////////////////////////
        rend[0].sharedMaterial = material[0];
        IsGreen[0] = false;
        GoodBox[0].IsGreen = false;       
        ////////////////////////////////
        rend[1].sharedMaterial = material[0];
        IsGreen[1] = false;
        GoodBox[1].IsGreen = false;
        ////////////////////////////////
        rend[2].sharedMaterial = material[0];
        IsGreen[2] = false;
        GoodBox[2].IsGreen = false;
        ////////////////////////////////
        rend[3].sharedMaterial = material[0];
        IsGreen[3] = false;
        GoodBox[3].IsGreen = false;
        ////////////////////////////////
    }




    void Update ()
    {
        if (GoodBox[0].IsGreen && GoodBox[0].IsBoxGood )
        {
            rend[0].sharedMaterial = material[1];
            IsGreen[0] = true;
        }

        if (GoodBox[1].IsGreen && GoodBox[1].IsBoxGood)
        {
            rend[1].sharedMaterial = material[1];
            IsGreen[1] = true;
        }

        if (GoodBox[2].IsGreen && GoodBox[2].IsBoxGood)
        {
            rend[2].sharedMaterial = material[1];
            IsGreen[2] = true;
        }

        if (GoodBox[3].IsGreen && GoodBox[3].IsBoxGood)
        {
            rend[3].sharedMaterial = material[1];
            IsGreen[3] = true;
        }


        if (RPad[0].Again)
        {
            DoOver();
            RPad[0].Again = false;
        }

        if (RPad[1].Again)
        {
            DoOver();
            RPad[1].Again = false;

        }

        if (RPad[2].Again)
        {
            DoOver();
            RPad[2].Again = false;

        }

        if (RPad[3].Again)
        {
            DoOver();
            RPad[3].Again = false;

        }

        if (IsGreen[0] && IsGreen[1] && IsGreen[2] && IsGreen[3] == true)
        {
            IsFinished = true;

        }

        if (IsFinished == true)
        {
            MoveP.SetActive(true);
        }
    }
}
