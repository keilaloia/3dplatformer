using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStuff : MonoBehaviour {

    public Collider m_ObjectCollider;
    public float pushPower = 2.0F;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) return;

        if (hit.moveDirection.y < -0.3F) return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }


    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
    }








    void Update () {
		
	}
}
