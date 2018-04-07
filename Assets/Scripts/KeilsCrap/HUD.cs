using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;

    public PlayerStats pHealth;
    
	void Update ()
    {
        HeartUI.sprite = HeartSprites[pHealth.currentHealth];
	}
}
