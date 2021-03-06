﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour {

    public float speed;
    public enum moveType { transforPoint, PhysicsPoint };
    public moveType moveTypes;
    public Transform[] pathpoints;

    public GameObject Player;


    public int curentPath = 0;
    public float reachPoint = 5f;
    
   
    // Use this for initialization

    
    void Start()
    {

    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
       
            switch (moveTypes)
            {

                case moveType.transforPoint:
                    transformPoint();
                    break;
                case moveType.PhysicsPoint:
                    PhysicsPoint();
                    break;

            }
        
    }

    void transformPoint()
    {

        Vector3 dir = pathpoints[curentPath].position - transform.position;
        Vector3 dirnor = dir.normalized;

        transform.Translate(dirnor * (speed * Time.fixedDeltaTime));

        if (dir.magnitude <= reachPoint)
        {
            curentPath++;

            if (curentPath >= pathpoints.Length) { curentPath = 0; }

        }


    }

    void PhysicsPoint()
    {



    }
    private void OnDrawGizmos()
    {
        if (pathpoints == null)
        {
            return;
        }

        foreach (Transform pathpoint in pathpoints)
        {
            if (pathpoint) { Gizmos.DrawWireSphere(pathpoint.position, reachPoint); }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            //Player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
