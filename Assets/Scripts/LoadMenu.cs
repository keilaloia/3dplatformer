using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{



	public GameObject BaseItem;

	
	void Update ()
			
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			BaseItem.SetActive(true);
		}
	}
}
