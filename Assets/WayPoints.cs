using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    public float[] Speed;
    public float PointReached;
    int speedindex;

    public GameObject NewCart;
    public Transform SpawnPoints;
    public Transform[] wayPoint;

   
    int index;
    

    // Use this for initialization
    void Start ()
    {

        speedindex = Random.Range(0, Speed.Length);
        	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 dir = wayPoint[index].position - transform.position;
        Vector3 dirnor = dir.normalized;
        transform.Translate(dirnor * (Speed[speedindex] * Time.fixedDeltaTime));


        if (dir.magnitude <= PointReached)
        {

            index++;
            //index = Random.Range(0, WayPointHolder.points.Length);


            if (index >= wayPoint.Length)
            {
                Instantiate(NewCart, SpawnPoints.position, SpawnPoints.rotation);
                Debug.Log("got one");
                Destroy(gameObject);
                
            }

        }

    }
}
