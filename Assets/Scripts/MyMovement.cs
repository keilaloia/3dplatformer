using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour {


    public CharacterController _pController;
    public Vector3 _mDirection = Vector3.zero;
    
    public Animator anim;
    public Transform pPoint;
    public GameObject PlayerMesh;
    public float speed;
    public float gravityScale;
    public float jumpforce;
    public float RotateSpeed;
    public float CamRotateSpeed;




    // Use this for initialization
    void Start()
    {
        _pController = GetComponent<CharacterController>();
       


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        RotateMesh();

        float yStore = _mDirection.y;
        _mDirection = (transform.forward * Input.GetAxis("LeftJoyY")) + (transform.right * Input.GetAxis("LeftJoyX"));
        _mDirection = _mDirection.normalized * -speed;
        //store the y of movedirection not currently used
        _mDirection.y = yStore;

        //if(Input.GetAxis("Horizontal") != 0)
        //{
        //    Camera.main.transform.position = new Vector3(0, 0, 0);
        //}
        if (_pController.isGrounded)
        {
            _mDirection.y = 0f;
            if (Input.GetButtonDown("ControllerJump"))
            {
                _mDirection.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * jumpforce);

            }
        }

        //player.addForce(25 * x_ * cos(earthAngle), 25 + x_ * sin(earthAngle));
        _mDirection.y = (_mDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime));
        _pController.Move(_mDirection * Time.deltaTime);


    }
      
    void RotateMesh()
    {
        if(Input.GetAxis("LeftJoyX") != 0 || Input.GetAxis("LeftJoyY") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pPoint.rotation.eulerAngles.y, 0);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_mDirection.x, 0, _mDirection.z));

            PlayerMesh.transform.rotation = Quaternion.Slerp(PlayerMesh.transform.rotation, newRotation, RotateSpeed * Time.deltaTime);

            //float MouseCameraHorz = Input.GetAxis("CamX") * CamRotateSpeed;
            float JoyStickHorz = Input.GetAxis("RightJoyX") * CamRotateSpeed;

           // pPoint.Rotate(0, MouseCameraHorz, 0);
            pPoint.Rotate(0, JoyStickHorz, 0);
        }

        anim.SetBool("IsGrounded", _pController.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("LeftJoyY")) + Mathf.Abs(Input.GetAxis("LeftJoyX"))));
    }
}
