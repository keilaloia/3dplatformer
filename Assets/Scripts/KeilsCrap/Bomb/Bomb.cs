using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


    public GameObject mygameobject;
    public Animator bombFlash;
    public bool boom;
    public float bombForce;
    public float bombHeight;
    public GameObject splat;
    private float timer;
    private Camera cam;



    void Awake()
    {
        cam = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("buttonThrow"))
        {
            bombFlash.SetTrigger("startTimer");
            Debug.Log("howdy");
        }
        else if(Input.GetButtonUp("buttonThrow"))
        {

            transform.parent = null;
            Rigidbody RB = mygameobject.AddComponent<Rigidbody>();
            //RB.velocity = new Vector3(RB.velocity.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight), playerrb.velocity.z * bombForce);
            RB.AddForce(cam.transform.up * (Mathf.Sqrt(-2.0f * Physics.gravity.y * bombHeight)),ForceMode.Impulse);
            RB.AddForce(cam.transform.forward * bombForce, ForceMode.Impulse);
            RB.AddForce(Physics.gravity * RB.mass * 3f, ForceMode.Acceleration);
            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

            Debug.Log("throw");
        }

        if (boom)
        {
            Instantiate(splat, mygameobject.transform.position, mygameobject.transform.rotation);
            mygameobject.SetActive(false);

            Debug.Log("triggeredasdf");
        }
    }

  

}
