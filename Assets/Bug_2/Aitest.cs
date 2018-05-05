﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Aitest : MonoBehaviour {

    public GameObject Player;
    public AudioClip[] FootSteps;
    public Transform eyes;
    public AudioSource Alert;
    public float NavSpeed;

    NavMeshAgent nav;
    AudioSource sounds;
    Animator anim;
    string state = "idle";
    bool Alive = true;
    float Wait;
    bool Alerted = false;
    float AlertRange = 20;


    // Use this for initialization
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        sounds = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        nav.speed = NavSpeed;
        anim.speed = 1f;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(eyes.position, Player.transform.position, Color.blue);
        // CHECKS IF ITS ALVE  
        if (Alive)
        {
            anim.SetFloat("velocity", nav.velocity.magnitude);
            if (state == "idle")
            {
                Vector3 RandPoint = Random.insideUnitSphere * AlertRange;
                NavMeshHit Hit;
                NavMesh.SamplePosition(transform.position + RandPoint, out Hit, 50, NavMesh.AllAreas);
                nav.SetDestination(Hit.position);

                state = "Walk";
            }

            // walking
            if (state == "Walk")
            {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {

                    state = "LookForPlayer";

                }
            }
            // loooking for the player
            if (state == "LookForPlayer")
            {

                if (Wait >= 0)
                {
                    Wait -= Time.deltaTime;
                    transform.Rotate(0, 100 * Time.deltaTime, 0);
                }
                else { state = "idle"; }

            }

            if (state == "Chase")
            {
                nav.destination = Player.transform.position;

                float dis = Vector3.Distance(transform.position, Player.transform.position);
                if (dis > 10f)
                {
                    state = "Hunt";

                }

                else if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {

                    if (Player.GetComponent<Player>().Alive)
                    {
                        state = "kill";
                        Player.GetComponent<Player>().Alive = false;
                        //Player.GetComponent<FirstPersonController>().enabled = false;
                        //deathCam.SetActive(true);
                        //deathCam.transform.position = Camera.main.transform.position;
                        //deathCam.transform.rotation = Camera.main.transform.rotation;
                        //Camera.main.gameObject.SetActive(false);
                        Alert.pitch = 0.7f;
                        Alert.Play();
                        Invoke("reset", 1f);
                    }

                }
            }

            if (state == "Hunt")
            {

                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "LookForPlayer";
                    Wait = 5f;
                    Alerted = true;
                    AlertRange = 5f;
                    eyeballCheck();

                }

            }

            if (state == "kill")
            {
                //deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, camPos.position, 10f * Time.deltaTime);
                //deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, camPos.rotation, 10f * Time.deltaTime);
                anim.speed = 1f;
                nav.SetDestination(Player.transform.position);
            }

            //nav.SetDestination(Player.transform.position);       
        }
    }

    public void footsteps(int Num)
    {

        sounds.clip = FootSteps[Num];

        sounds.Play();


    }

    public void eyeballCheck()
    {

        if (Alive)
        {

            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, Player.transform.position, out rayHit))
            {
                print("hit" + rayHit.collider.gameObject.name);
                if (rayHit.collider.gameObject.name == "Player")
                {
                    if (state != "Kill")
                    {
                        state = "Chase";
                        nav.speed = 3.5f;
                        anim.speed = 2.2f;

                        Alert.Play();

                    }
                }

            }

        }

    }
    void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //die//
    public void death()
    {
        anim.SetTrigger("dead");
        anim.speed = 1f;
        Alive = false;


    }

}
