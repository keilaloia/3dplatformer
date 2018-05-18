using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{

    public int maxHealth = 5;

    public float uiTimer = 5;
    public float TimerEnded;
    public Image Hearts;
    public Animator MyHearts;
    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public bool Damaged;

    [HideInInspector]
    public bool heal;

    private float startTime;
    private bool HeartShow = false;
    private bool heartsCheck = false;

    private static PlayerStats _Instance;
    public static PlayerStats instance
    {
        get
        {
            return _Instance;
        }
    }
    // Use this for initialization
    void Awake()
    {

        if (_Instance == null)
        {
            _Instance = this;
        }
        else
            Destroy(gameObject);


   
    }
    void Start()
    {
        startTime = uiTimer;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        //timer constantly checks to see if our player has been attacked and shows ui only if been attacked and turns it back off once ui check is over. it leaves health up if player is missing health
        Timer();

       
        //GainHealth();

        //LoseHealth();


        //Debug.Log(uiTimer);
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            // SceneManager.LoadScene(2);
            Debug.Log(" level load request for: " + name);

            Application.LoadLevel("death");
            //SceneManager.LoadScene("death");

        }
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
        if (heartsCheck == false && currentHealth == maxHealth)
        {
            //Hearts.enabled = false;
            HeartShow = false;
            MyHearts.SetBool("show", HeartShow);
            //Debug.Log("falsebool");
            //Debug.Log(HeartShow);
        }
        //saftey checks to see if we have been attacked and if we have and are missing health turn on ui
        else if (heartsCheck == true || currentHealth != maxHealth)
        {
            HeartShow = true;
            MyHearts.SetBool("show", HeartShow);
            // Debug.Log("truebool");
        }
    }
    //access these 2 methods from any script to take damage or gain health

    public void GainHealth()
    {
        heartsCheck = true;
        uiTimer = startTime;
        currentHealth += 1;
        Debug.Log("keyRightcheck");
        // Debug.Log(currentHealth);

    }
    public void LoseHealth()
    {

        heartsCheck = true;
        uiTimer = startTime;
        currentHealth -= 1;


        //Debug.Log(currentHealth);

    }

    //public void LoadLevel(string name)
    //{
    //    Debug.Log(" level load request for: " + name);

    //    SceneManager.LoadScene(2);
    //    //Application.LoadLevel(name);
    //}
}


