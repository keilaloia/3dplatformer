using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorRadius : MonoBehaviour {
    

    private float _maxDistance = 5.0f;

    public Transform constrainedPlayer;

    private Vector3 _constrainxz;
    private Vector3 _anchorxz;
	// Use this for initialization
	void Start ()
    {
        _constrainxz = new Vector3(constrainedPlayer.position.x, 0, constrainedPlayer.position.z);
        _anchorxz = new Vector3(transform.position.x, 0, transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 vec = constrainedPlayer.position - transform.position;
        if(vec.magnitude > _maxDistance)
        {
            constrainedPlayer.position = transform.position + vec.normalized * _maxDistance;
        }
       
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _maxDistance);
    }
}
