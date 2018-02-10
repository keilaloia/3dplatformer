using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    private RaycastHit _hit;
    private CameraSingleTon _cams;
    private Transform _mTrans;
    private Vector3 _fDist;

    public float MouseCamSpeed;
    public float JoyCamSpeed;
    public float maxViewAngle;
    public float minViewAngle;

    public Vector3 Offset;
    public Transform pPoint;

    public bool InvertY;
    // Use this for initialization
    void StartingInit()
    {
        _cams = CameraSingleTon.instance.GetComponent<CameraSingleTon>();
        _mTrans = GetComponent<Transform>();
        //pivot crap
        pPoint.transform.position = _mTrans.transform.position;
        pPoint.transform.parent = null;
        //cursor crap
        Cursor.lockState = CursorLockMode.Locked;
    }
	void Start ()
    {
        StartingInit();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        OffsetCaste();
        cameraRotation();
	}

    void OffsetCaste()
    {
        //code for when camera is colliding with object to not clip through objects fix in post, fine for prototype
        if(Physics.Linecast(transform.position, transform.position + Offset, out _hit))
        {
            _fDist = transform.position + Offset;
        }
        else
        {
            _fDist = transform.position + Offset;
        }

        _cams.transform.position = _fDist;
        Debug.DrawLine(transform.position, transform.position + Offset, Color.blue);
    }

    void cameraRotation()
    {
        pPoint.transform.position = _mTrans.position;
        //possible different x and y rotation speeds play with it first

        //Mouse
        float mouseHorz = Input.GetAxis("CamX") * MouseCamSpeed;
        float mouseVertz = Input.GetAxis("CamY") * MouseCamSpeed;

        //Joy Stick
        float joyHorz = Input.GetAxis("JoyX") * JoyCamSpeed;
        float joyVertz = Input.GetAxis("JoyY") * JoyCamSpeed;

        //X Rotation
        pPoint.Rotate(0, -mouseHorz, 0);
        pPoint.Rotate(0, -joyHorz, 0);

        //Y Rotation
        if(InvertY == true)
        {
            pPoint.Rotate(-mouseVertz, 0, 0);
            pPoint.Rotate(-joyVertz, 0, 0);

        }
        else
        {

            pPoint.Rotate(mouseVertz, 0, 0);
            pPoint.Rotate(joyVertz, 0, 0);
        }

        //making all the shit above work :D
        //move camera based on the current rotation of myplayer transform & the original offset
        float desiredXAngle = pPoint.eulerAngles.x;
        float desiredYAngle = pPoint.eulerAngles.y;

        _cams.transform.rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        _cams.transform.position = _mTrans.position - (_cams.transform.rotation * Offset);
        ///this gives camera the janky y clipping
        //if(_cams.transform.position.y < _mTrans.position.y)
        //{
        //    _cams.transform.position = new Vector3(_cams.transform.position.x, _mTrans.position.y - .5f, _cams.transform.position.z);
        //}

        if(pPoint.rotation.eulerAngles.x > minViewAngle && pPoint.rotation.eulerAngles.x < 180)
        {
            pPoint.rotation = Quaternion.Euler(minViewAngle, desiredYAngle, 0);
        }
        //if(pPoint.rotation.eulerAngles.x > 180f && pPoint.rotation.eulerAngles.x < 360f + maxViewAngle)
        //{
        //    pPoint.rotation = Quaternion.Euler(360f + maxViewAngle, desiredYAngle, 0);
        //}
        _cams.transform.LookAt(_mTrans);




    }
}
