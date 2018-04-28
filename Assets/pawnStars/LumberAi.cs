using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LumberAi : MonoBehaviour {

    Transform Player;
    public Transform head;
    static Animator anim;

    string state = "Patrol";
    public GameObject[] wayPoints;

    int currentWP = 0;
    public float rotationSpeed;
    public float Speed;
    public float WayPoint;
    


	// Use this for initialization
	void Start ()
    {
        //Player = PlayerManager.instance.player.transform;
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 Dir = Player.position - this.transform.position;
        Dir.y = 0;
        float angle = Vector3.Angle(Dir, this.transform.forward);

        if (state == "Patrol" && wayPoints.Length > 0)
        {

            //anim.SetBool("IsIdle", false);
            //anim.SetBool("IsWAlking", true);
            if (Vector3.Distance(wayPoints[currentWP].transform.position, transform.position) < WayPoint)
            {
                //currentWP++;
                //if (currentWP >= wayPoints.Length)
                //{
                //    currentWP = 0;
                //}

                currentWP = Random.Range(0, wayPoints.Length);

            }
            Dir = wayPoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dir), rotationSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * Speed);
        }

        if (Vector3.Distance(Player.position, this.transform.position) < 10 &&( angle < 30 || state == "Chase"))
        {

            state ="Chase";  

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Dir), Speed * Time.deltaTime);
            //anim.SetBool("Idle",false);
            if (Dir.magnitude > 10)
            {
                this.transform.Translate(0, 0,Time.deltaTime *Speed);
                //anim.SetBool("IsWAlking", true);
            }
            else
            {
                //anim.SetBool("IsAttack", true);
                //anim.SetBool("IsWAlling", false);
            }

        }

        else
        {

            //anim.SetBool("IsIdle", true);
            //anim.SetBool("IsAttack", false);
            //anim.SetBool("IsWAlking", false);
            state = "Patrol";
        }
	}
}
