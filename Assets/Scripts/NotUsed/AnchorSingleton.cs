using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class AnchorSingleton : MonoBehaviour
{

    private static AnchorSingleton _Singleton;

    public static AnchorSingleton Singleton
    {
        get { return _Singleton; }
    }
	// Use this for initialization
	void Awake()
	{
	    if (_Singleton == null)
	    {
	        _Singleton = this;
	    }
        else 
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
