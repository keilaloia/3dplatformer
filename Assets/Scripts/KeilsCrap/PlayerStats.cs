using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour {

    public int maxHealth = 5;
    
    public float uiTimer = 5;
    public float TimerEnded;
    public Image Hearts;
    public Animator MyHearts;
    [HideInInspector]
    public int currentHealth;


    private float startTime;
    private bool HeartShow = false;
    private bool heartsCheck = false;
    
	// Use this for initialization
	void Awake ()
    {
        startTime = uiTimer;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //timer constantly checks to see if our player has been attacked and shows ui only if been attacked and turns it back off once ui check is over. it leaves health up if player is missing health
        Timer();

        
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            heartsCheck = true;
            uiTimer = startTime;
            currentHealth -= 1;
            
            Debug.Log("keyleftcheck");
            //Debug.Log(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            heartsCheck = true;
            uiTimer = startTime;
            currentHealth += 1;
            Debug.Log("keyRightcheck");
           // Debug.Log(currentHealth);
          
        }

        //Debug.Log(uiTimer);
    }

    void Timer()
    {
        uiTimer -= Time.deltaTime;
      
        //constantly check whats going on
        if (uiTimer <= 0.0f)
        {
            uiTimer = startTime;
            heartsCheck = false;
        }
      
        //turns ui off if nothing happened and we have max health
        if(heartsCheck == false && currentHealth == maxHealth)
        {
            //Hearts.enabled = false;
            HeartShow = false;
            MyHearts.SetBool("show",HeartShow);
            //Debug.Log("falsebool");
            //Debug.Log(HeartShow);
        }
        //saftey checks to see if we have been attacked and if we have and are missing health turn on ui
        else if(heartsCheck == true || currentHealth != maxHealth)
        {
            HeartShow = true;
            MyHearts.SetBool("show", HeartShow);
           // Debug.Log("truebool");
        }
    }
}
