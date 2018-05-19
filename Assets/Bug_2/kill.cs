//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class kill : MonoBehaviour {

//    public float TimeBetweenAttacks = 1f;
//    public int Damage  = 1;
//    public GameObject test;
//    bool testRang;
//    float time;
//    // Use this for initialization
//    void Start () {
//		//Player health;
//        // ememyHealth
//	}
	
//	// Update is called once per frame
//	void Update ()
//    {

//        time += Time.deltaTime;

//        if (/*Check if the player i sin range to attack and efects its health*/ )
//        {
//            Attack();
//        }
        	
//	}

//    void OnTriggerEnter(Collider col)
//    {

//        if (col.gameObject == test)
//        {

//            testRang = true;

//        }

//    }
//    void OnTriggerExit(Collider col)
//    {

//        if (col.gameObject == test)
//        {

//            testRang = false;

//        }

//    }

//    void Attack()
//    {
//        time = 0;

//        if (/* players Curent Health*/)
//        {

//                // playerHeath.takeDamage(Damage);

//        }
//    }
//}
