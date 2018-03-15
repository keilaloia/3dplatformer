﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class JumpPad : MonoBehaviour
{
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
        }
    }
    // whatHitMe.GetComponent<MyMovement>()._mDirection.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * 20);

    void Update()
    {

    }
}