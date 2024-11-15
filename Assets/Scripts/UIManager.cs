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
            Time.timeScale = 0f;
        }

//1, 2, 3, 4 tuşlarına basıldığında oyun hızını değiştirme
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseGameplay();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FastForward1x();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FastForward2x();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FastForward4x();
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

//Pause Menu Tuşları
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnQuitMainMenuPress()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnQuitDesktopPress()
    {
        Application.Quit();
    }

//Gameplay menüden oyun hızını değiştirme
    public void PauseGameplay()
    {
        Time.timeScale = 0f;
    }
    public void FastForward1x()
    {
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale =1f; 
        }
    }
    public void FastForward2x()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale =1f; 
        }
    }
    public void FastForward4x()
    {
        if(Time.timeScale == 1f || Time.timeScale == 2f)
        {
            Time.timeScale = 4f;
        }
        else
        {
            Time.timeScale =1f; 
        }
    }
}
