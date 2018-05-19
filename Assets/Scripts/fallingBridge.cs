
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBridge : MonoBehaviour {

    public static fallingBridge instance;

    public Transform currentParent;
	private Movement movesingleton;
    private MeshRenderer thismesh;
    [HideInInspector]
    public bool isfalling = false;
    public GameObject target;
    public float step;

    private bool testbs;

    private float currentTimer;
    private float Timer = 3f;

    // Use this for initialization
    void Start ()
	{
        fallingBridge.instance = this;

        movesingleton = Movement.instance.GetComponent<Movement>();
        thismesh = GetComponent<MeshRenderer>();
        currentTimer = Timer;
	}

    void Update()
    {
        

        if (testbs)
        {
            //currentParent.transform.localRotation = Quaternion.Euler(-90, 0, 0);

            isfalling = false;
            //Debug.Log("isfallingisfalse");
        }
    }
    // Update is called once per frame
    void FixedUpdate ()
	{

        if (isfalling)
        {
            //currentParent.rotation = Quaternion.RotateTowards(transform.rotation, target, step);

            currentParent.transform.localRotation = Quaternion.Lerp(currentParent.transform.localRotation, Quaternion.Euler(-90, 0, 0), step * Time.deltaTime);
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                testbs = true;
                Timer = currentTimer;
            }
        }

        //Debug.Log(Timer);

    }

    private void OnTriggerEnter(Collider other)
	{
       // Debug.Log("entertriggered");
		if(other.gameObject.layer == 13 && movesingleton.IsAttacking)
		{
            thismesh.enabled = false;
            isfalling = true;
           // Debug.Log("worked");
            
		}

	}

    private void OnTriggerExit(Collider other)
    {
       // Debug.Log("exit triggered");
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("triggerstay");
    }
}
