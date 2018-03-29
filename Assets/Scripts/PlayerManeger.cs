using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour {

    #region Singleton
    public static PlayerManeger instance;

    void Awake()
    { instance = this; }
    #endregion

    public GameObject Player;

}