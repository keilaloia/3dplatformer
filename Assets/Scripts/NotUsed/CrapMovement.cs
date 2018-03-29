using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapMovement : MonoBehaviour
{

	private float _speed = 10f;
	private float _jumpforce = 15f;
	private float _gravityscale = 5f;
	private float _RotateSpeed = 10f;
	
	private CharacterController _Pcharacter;
	private Vector3 _mDirection;
	//Public//
	public Animator anim;
	public Transform pPoint;
	public Transform CamPoint;
	public GameObject PlayerModel;
	


	
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
		float yStore = _mDirection.y;
		_mDirection = ((transform.forward * Input.GetAxis("Vertical")) + transform.right * Input.GetAxis("Horizontal") * Mathf.Cos(_mDirection.x));
		_mDirection = _mDirection.normalized * -_speed;
		//store the y of movedirection not currently used
		_mDirection.y = yStore;
		///////////////////////////camera rotation
	   // if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		
		
		if(_Pcharacter.isGrounded)
		{
			_mDirection.y = 0f;
			if (Input.GetButtonDown("Jump"))
			{
				_mDirection.y = _jumpforce;
			}
		}

		//player.addForce(25 * x_ * cos(earthAngle), 25 + x_ * sin(earthAngle));
		_mDirection.y = (_mDirection.y + (Physics.gravity.y * _gravityscale * Time.deltaTime));
		_Pcharacter.Move(_mDirection * Time.deltaTime);
	   // _Pcharacter.Move(pPoint.transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")))));


		//moves the player in different directions based on camera look direction
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			transform.rotation = Quaternion.Euler(0f, pPoint.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(_mDirection.x, 0f, _mDirection.z));
			PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation, newRotation, _RotateSpeed * Time.deltaTime);
			float MouseCameraHorz = Input.GetAxis("CamX") * _RotateSpeed;
			float JoyStickHorz = Input.GetAxis("JoyX") * _RotateSpeed;

			pPoint.Rotate(0, MouseCameraHorz, 0);
			pPoint.Rotate(0, JoyStickHorz, 0);


		}


		anim.SetBool("IsGrounded", _Pcharacter.isGrounded);
		anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
	}
}
