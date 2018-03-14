using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMotor : MonoBehaviour
{
    [Header("Acceleration Settings")]
    public float MaxSpeed;
    public float ZeroToMax;
    public float MaxToZero;

    private float AccelRatePerSecond;
    private float DecelRatePerSecond;

    [Header("Other Things")]
    public float speed = 0.0f;

    public float maxRotationPerSecond = 45.0f;

    [HideInInspector]
    public Vector3 wishMove;

    public Rigidbody rbody;

    void Start()
    {
        AccelRatePerSecond = MaxSpeed / ZeroToMax;
        DecelRatePerSecond = -MaxSpeed / MaxToZero;
    }

    void Update()
    {
        // gathering input
        Vector3 input = new Vector3(Input.GetAxis("LeftJoyX"),
                                    0.0f,
                                    Input.GetAxis("LeftJoyY"));

        wishMove = input;
    }

    void FixedUpdate()
    {
        // only change my direction if i'm pushing the stick
        if (wishMove.magnitude != 0.0f)
        {
            // clamp change in rotation and
            // face desired direction
            transform.forward = Vector3.RotateTowards(transform.forward,
                                                      wishMove.normalized,
                                                      Mathf.Deg2Rad * maxRotationPerSecond * Time.deltaTime,
                                                      0.0f);
        }

        // move forward
        Vector3 finalPosition = rbody.position + (transform.forward * wishMove.magnitude * speed * Time.deltaTime);
        rbody.MovePosition(finalPosition);
    }
}