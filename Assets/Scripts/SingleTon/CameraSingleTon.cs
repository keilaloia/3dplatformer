using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleTon : MonoBehaviour {

    [HideInInspector]
    new public Camera camera;
    //voodoo magic instance for one object better way to find objects
	private static CameraSingleTon _instance;
    public static CameraSingleTon instance
    {
        get
        {
            return _instance;
        }
    }
    public float shakeDuration;
    public float shakeDecrease;
    public float shakeForce;
    private float currentshakeDuration;
    public bool doShake;

    Vector3 originalPos;
    //safety check
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        currentshakeDuration = shakeDuration;

        doShake = false;
        camera = GetComponent<Camera>();
        originalPos = camera.transform.localPosition;
    }

    public void cameraShake()
    {

        Vector3 startRot = transform.rotation.eulerAngles;
        if(doShake)
        {
            if (shakeDuration > 0)
            {
                Vector3 rando = Random.insideUnitCircle * shakeForce;
                transform.Rotate(1 * rando.y, 0, 0);
                shakeDuration -= Time.deltaTime * shakeDecrease;


            }
            else
            {
                doShake = false;
                transform.rotation = Quaternion.Euler(startRot);
                shakeDuration = currentshakeDuration;
                camera.transform.localPosition = originalPos;
            }
        }
       // transform.rotation = startRot;

    }
    void Update()
    {
        cameraShake();
    }
    
    // Look into making a random direction vector property
    // Look into making a co-routine for shaking camera for a set amount of seconds
}
