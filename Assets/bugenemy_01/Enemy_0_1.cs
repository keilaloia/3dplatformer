using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;


public class Enemy_0_1 : MonoBehaviour
{
    static Animator anim;
    NavMeshAgent nav;
    Transform target;

    public float lookRadius = 10f;
    // Use this for initialization
    void Start()
    {
        target = PlayerManeger.instance.Player.transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            nav.SetDestination(target.position);
            if (distance <= nav.stoppingDistance)
            {

                ////attack 
                //anim.SetTrigger("IsWalking");
                FaceTarget();

            }
        }
    }
    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRatation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, lookRadius);

    }
}
