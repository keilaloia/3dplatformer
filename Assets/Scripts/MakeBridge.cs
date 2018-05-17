using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBridge : MonoBehaviour {

    public float goTo = 90f;
    public GameObject pillar;
    public GameObject Tbox;

	void Start ()
    {
		
	}
    private void OnCollisionEnter(Collision whatHitMe)
    {
        if (whatHitMe.gameObject.CompareTag("Box"))
        {
            pillar.transform.Rotate(Vector3.left * goTo);
            DestroyObject(Tbox);
        }
    }

    void Update ()
    {
        //pillar.transform.Rotate(Vector3.left * 50);

    }
}
