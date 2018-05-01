using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolution;

    public static bool GameIsPaused = false;
    public GameObject PauseMenu;


    void Start()
    {
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + " x " + resolution[i].height;
            options.Add(option);

            if(resolution[i].width == Screen.currentResolution.width &&
               resolution[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        //Menu
        StartMenu(Input.GetButtonDown("Hamburger"));
    }

    public void SetResolution (int resoltuionIndex)
    {
        Resolution resolutionz = resolution[resoltuionIndex];
        Screen.SetResolution(resolutionz.width, resolutionz.height, Screen.fullScreen);
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
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

    public void StartMenu(bool bHam)
    {
        if (bHam)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
