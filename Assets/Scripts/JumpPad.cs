using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class JumpPad : MonoBehaviour
{
    Movement movement;
    public Rigidbody player;
    public int force = 20;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Player"))
        {
            player.AddForce(0, force, 0);
            
                //(Input.GetButtonDown("ControllerJump"));

        }
    }
    

    void Update()
    {

    }
}
