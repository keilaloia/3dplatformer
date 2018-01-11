using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    public void LoadLevel( string name)
    {
        Debug.Log(" level load request for: " + name);

        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Request Application.Quit");

        Application.Quit();
    }

    public void Resume(GameObject canvas)
    {
        Debug.Log(" Resuming Game ");

        canvas.SetActive(false);

    }
}
