using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    void Update()
    {
        // Escape tuşuna basıldığında pause menu aç
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }

    //Start Menu Tuşları
    public void OnStartPress()
    {
        SceneManager.LoadScene("UIScene");
    }
    public void OnSettingsPress()
    {

    }
    public void OnQuitPress()
    {
        Application.Quit();
    }

    //Pause menu  tuşları
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
    }
    public void OnQuitMainMenuPress()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnQuitDesktopPress()
    {
        
    }
}
