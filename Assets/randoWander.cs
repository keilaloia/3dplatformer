using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randoWander : MonoBehaviour {

    NavMeshAgent nav;
    public float wait;
    public float timer;
   
    // Use this for initialization
    void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= wait)
        {


            timer = 0;

            Vector3 RandPoint = Random.insideUnitSphere * 20;
            NavMeshHit Hit;
            NavMesh.SamplePosition(transform.position + RandPoint, out Hit, 50, NavMesh.AllAreas);
            nav.SetDestination(Hit.position);

        }
    }
}
