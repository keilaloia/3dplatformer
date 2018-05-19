using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int StartHealth = 100;
    public int curentHealth;
    public AudioClip death;

    bool isHurt;
    bool Damage;

	// Use this for initialization
	void Start ()
    {
        curentHealth = StartHealth;	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Damage)
        {
            Debug.Log("dont hit me");
        }

        else
        {
            Debug.Log("fight");
        }

        Damage = false;
	}

    public void takeDamage(int amount)
    {

        Damage = true;

        curentHealth -= amount;

        if (curentHealth <= 0 & !isHurt)
        {
            Death();
        }

    }

    public  void Death()
    {

        isHurt = true;

        Destroy(gameObject);

    }
}
