using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Resources resources;

// Resource texts
    public TextMeshProUGUI[] MoneyText;
    public TextMeshProUGUI[] DopamineText;
    public TextMeshProUGUI[] CoalText;
    public TextMeshProUGUI[] AlcoholText;
    public TextMeshProUGUI[] EnergyText;
    string _money => resources.goins + "";
    string _dopamine => resources.dopamin + "";
    string _coal => resources.coal + "";
    string _alcohol => resources.alcohol + "";
    string _energy => resources.energy + "";

    bool isPaused = false;
    int gameSpeed;

    void Update()
    {
// Escape tuşuna basıldığında pause menu aç/kapa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                OnResumePress();
            }
            else
            {
                pauseMenu.SetActive(true);
                PauseGameplay();
            }
        }

// 1, 2, 3,tuşlarına basıldığında oyun hızını değiştirme, space tuşuna basınca zamanı durdur/başlat
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == true)
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                PauseGameplay();
            }
        }
       /* if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FastForward1x();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FastForward4x();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FastForward8x();
        }*/

// Resource ların UI da görünmesi
        for(int i = 0; i < MoneyText.Length; i++)
        {
            MoneyText[i].text = _money;
        }
        for(int i = 0; i < DopamineText.Length; i++)
        {
            DopamineText[i].text = _dopamine;
        }
        for(int i = 0; i < CoalText.Length; i++)
        {
            CoalText[i].text = _coal;
        }
        for(int i = 0; i < AlcoholText.Length; i++)
        {
            AlcoholText[i].text = _alcohol;
        }
        for(int i = 0; i < EnergyText.Length; i++)
        {
            EnergyText[i].text = _energy;
        }

    }
//-------------------------------------------------------------------------------------------------

// Start Menu Tuşları
    public void OnStartPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnSettingsPress()
    {

    }
    public void OnQuitPress()
    {
        Application.Quit();
    }

// Pause Menu Tuşları
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void OnQuitMainMenuPress()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnQuitDesktopPress()
    {
        Application.Quit();
    }

// Gameplay menüden oyun hızını değiştirme
    public void PauseGameplay()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void FastForward1x()
    {
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale =1f; 
        }
    }
    public void FastForward4x()
    {
        if(Time.timeScale == 1f || Time.timeScale== 8f)
        {
            Time.timeScale = 4f;
            isPaused = false;
        }
        /*else gerek yok bence kola bey de baksın
        {
            Time.timeScale =1f; 
        }*/
    }
    public void FastForward8x()
    {
        if(Time.timeScale == 1f || Time.timeScale == 4f)
        {
            Time.timeScale = 8f;
            isPaused = false;
        }
        else
        {
            Time.timeScale =1f; 
        }
    }

}
