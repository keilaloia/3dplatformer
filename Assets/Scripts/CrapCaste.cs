using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapCaste : MonoBehaviour
{

	private Rigidbody _rb;
	private RaycastHit _hit;
	private CameraSingleTon _cams;
    private AnchorSingleton _PivotPoint;
	private Transform _me;
	private Vector3 _fDist;
    private float _RotateSpeed = 1;
    public float length;
    public Vector3 offset;
    //couldnt get to work with singlton
    public Transform pPoint;


    // Use this for initialization
    void Start ()
	{
        GetCompInit();

        pPoint.transform.position = _me.transform.position;
        pPoint.transform.parent = _me.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
        CalcfDist();
        cameraRotation();
	}

    void GetCompInit()
    {
        // offset = new Vector3(0, 1.5f, -5.0f);
        _rb = GetComponent<Rigidbody>();
        _cams = CameraSingleTon.instance.GetComponent<CameraSingleTon>();
        _me = GetComponent<Transform>();
        _PivotPoint = GetComponent<AnchorSingleton>();
    }
    void CalcfDist()
    {
        caste();
        _cams.transform.position = _fDist;
        Debug.DrawLine(transform.position, transform.position + offset, Color.blue);

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
        float horizontal = Input.GetAxis("Mouse X") * _RotateSpeed;
        _me.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * _RotateSpeed;
        pPoint.transform.Rotate(-vertical, 0, 0);

        //move camera based on the current rotation of the target & the original offset
        float desiredYAngle = _me.eulerAngles.y;
        float desiredXAngle = pPoint.transform.eulerAngles.x;
        _cams.transform.rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        _cams.transform.position = _me.position - (_cams.transform.rotation * offset);

        if(_cams.transform.position.y < _me.position.y)
        {
            _cams.transform.position = new Vector3(_cams.transform.position.x, _me.position.y -.5f, _cams.transform.position.z);
        }

        _cams.transform.LookAt(_me);

    }
}
