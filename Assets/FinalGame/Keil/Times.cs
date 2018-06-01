using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Times : MonoBehaviour {


    public float Timer;
    private float StartTime;

    [SerializeField]
    private Text myTextelement;
    public GameObject disable;
    public string[] InputText;


    private int i = 0;
    private bool TimeTick = false;

    private void Start()
    {
        StartTime = Timer;
        myTextelement.text = InputText[0];


    }
    // Update is called once per frame
    private void Update ()
    {
        Timer -= Time.deltaTime;

        bool shouldSkip = Input.GetKeyUp(KeyCode.L) || Timer <= 0;
        if (shouldSkip)
        {
            TextDial();
            Timer = StartTime;
            TimeTick = false;
        }
    }



    public void TextDial()
    {
        i++;

        if (InputText.Length <= i)
        {
            disable.SetActive(false);
            return;
        }

        myTextelement.text = InputText[i];
    }





}
