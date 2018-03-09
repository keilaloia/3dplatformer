using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {

    
    public FloorPad[] GoodBox;
    public bool[] IsGreen;
    public Material[] material;
    public Renderer[] rend;
    public FloorPad floor;
    public GameObject Nice;

    public bool IsFinished;



    void Start ()
    {

	}


    void OnSwitch()
    {
        Nice.SetActive(true);
    }


    void Update ()
    {
        if (GoodBox[0].IsGreen == true && GoodBox[0].IsBoxGood == true)
        {
            IsGreen[0] = true;
        }
        if (GoodBox[0].IsGreen == true)
        {
            rend[0].sharedMaterial = material[1];
        }
        if (GoodBox[1].IsGreen == true && GoodBox[1].IsBoxGood == true)
        {
            IsGreen[1] = true;
        }
        if (GoodBox[1].IsGreen == true)
        {
            rend[1].sharedMaterial = material[1];
        }
        if (IsGreen[0] && IsGreen[1] == true)
        {
            IsFinished = true;
            OnSwitch();
        }
    }
}
