using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrapMovement : MonoBehaviour
{

	private float _speed = 10f;
    private float _jumpforce = 15f;
    private CharacterController _Pcharacter;
    private Vector3 _mDir;
    private float _gravityscale = 5f;
    
	// Use this for initialization
	void Start ()
    {
        _Pcharacter = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        float yStore = _mDir.y;
        _mDir = ((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")));
        _mDir = _mDir.normalized * -_speed;
        _mDir.y = yStore;
        
        if(_Pcharacter.isGrounded)
        {
            _mDir.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                _mDir.y = _jumpforce;
            }
        }

        
        

        _mDir.y = (_mDir.y + (Physics.gravity.y * _gravityscale * Time.deltaTime));
        _Pcharacter.Move(_mDir * Time.deltaTime);
    }
}
