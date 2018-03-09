using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class JumpPad : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody player;
    public int force = 20;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Player"))
        {
            whatHitMe.GetComponent<MyMovement>()._mDirection.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * 20);
        }
        //player.AddForce(0, force, 0);
    }
    
    void Update()
    {

    }
}
