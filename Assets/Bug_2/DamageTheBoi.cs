using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTheBoi : MonoBehaviour {

    private PlayerStats statsins;
   public float time;
    public float ctime;
    public float TBAttacks;

    bool Damage = false;
    // Use this for initialization
    void Start ()
    {
        statsins = PlayerStats.instance.GetComponent<PlayerStats>();
        ctime = time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("time" + time);
        //time += Time.deltaTime;

        //if (time >= 1)
        //{
        //    time = 0;
        //    if (Damage)
        //    {
                
        //        Attack();
                
        //    }

        //}
        	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 10)
        {
            //Debug.Log("entertrigger");

            Damage = true;

        }

    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log("time" + time);
        time += Time.deltaTime;

        if (time >= TBAttacks  && col.gameObject.layer == 10)
        {
            time = 0;
            if (Damage)
            {

                Attack();

            }

        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 10)
        {
            Damage = false;
        }
    }

    void Attack()
    {

        time = ctime;
        statsins.LoseHealth();
        

    }
}
