using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapCaste : MonoBehaviour
{
  
	private Rigidbody _rb;
	private RaycastHit _hit;
	private CameraSingleTon _cams;
    /// shits broken
    private AnchorSingleton _PivotPoint;
    /// <summary>
	private Transform _me;
	private Vector3 _fDist;
    private float _RotateSpeed = .2f;
    private float _camSpeed = 2f;
    
    public float length;
    public Vector3 offset;
    //fix your pivot point singleton  that way its not public and place below

    //couldnt get to work with singleton so use pPoint instead
    public Transform pPoint;
    public float maxViewAngle;
    public float minViewAngle;

    public bool InvertY;


    // Use this for initialization
    void Start ()
	{
        GetCompInit();
        pPoint.transform.position = _me.transform.position;

        pPoint.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{

        //Vector3 forwardMovement = Camera.main.transform.forward * Input.GetAxis("Vertical");
        //Vector3 rightMovement = Camera.main.transform.right * Input.GetAxis("Horizontal");
        //Vector3 totalMovement = forwardMovement + rightMovement;
        //totalMovement.y = 0f;
        //transform.position += totalMovement * Time.deltaTime * _camSpeed;

        CalcfDist();
        cameraRotation();
	}

    void GetCompInit()
    {

        _rb = GetComponent<Rigidbody>();
        _cams = CameraSingleTon.instance.GetComponent<CameraSingleTon>();
        _me = GetComponent<Transform>();
        //////////////////do not use does not work for some reason below
        _PivotPoint = GetComponent<AnchorSingleton>();
    }
    void CalcfDist()
    {
        caste();
        _cams.transform.position = _fDist;
        Debug.DrawLine(transform.position, transform.position - offset, Color.blue);

    }
    void caste()
	{
		if(Physics.Linecast(transform.position, transform.position + offset, out _hit))
		{
			_fDist = transform.position + offset;

		}
		else
		{
			_fDist = transform.position + offset;
		}
	}

    void cameraRotation()
    {
        pPoint.transform.position = _me.transform.position;

        float horizontal = Input.GetAxis("CamX") * _RotateSpeed;
        float CamHorz = Input.GetAxis("JoyX") * _camSpeed;
        pPoint.Rotate(0, horizontal, 0);
        pPoint.Rotate(0, CamHorz, 0);
        Debug.Log(CamHorz);

        float vertical = Input.GetAxis("CamY") * _RotateSpeed;
        float CamVertz = Input.GetAxis("JoyY") * _camSpeed;

        Debug.Log(CamVertz);

        float desiredYAngle = pPoint.eulerAngles.y;
        float desiredXAngle = pPoint.eulerAngles.x;

        if (InvertY == true)
        {
            pPoint.Rotate(-vertical, 0, 0);
            pPoint.Rotate(-CamVertz, 0, 0);


        }
        else
        {
            pPoint.Rotate(vertical, 0, 0);
            pPoint.Rotate(CamVertz, 0, 0);

        }

        //limit up and down camera rotate
        if (pPoint.rotation.eulerAngles.x > minViewAngle && pPoint.rotation.eulerAngles.x < 180f)
        {
           pPoint.rotation = Quaternion.Euler(minViewAngle, desiredYAngle, 0);
        }

        if (pPoint.rotation.eulerAngles.x > 180f && pPoint.rotation.eulerAngles.x < 360f + maxViewAngle)
        {
            pPoint.rotation = Quaternion.Euler(360f + maxViewAngle, desiredYAngle , 0);
        }
        //move camera based on the current rotation of the target & the original offset
        _cams.transform.rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        _cams.transform.position = _me.position - (_cams.transform.rotation * offset);

        if(_cams.transform.position.y < _me.position.y)
        {
            _cams.transform.position = new Vector3(_cams.transform.position.x, _me.position.y -.5f, _cams.transform.position.z);
        }
        _cams.transform.LookAt(_me);




    }
}
