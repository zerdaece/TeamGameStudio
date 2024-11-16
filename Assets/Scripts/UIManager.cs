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

    void Update()
    {
// Escape tuşuna basıldığında pause menu aç/kapa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            PauseGameplay();
        }

// 1, 2, 3,tuşlarına basıldığında oyun hızını değiştirme, space tuşuna basınca zamanı durdur/başlat
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
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

//Start Menu Tuşları
    public void OnStartPress()
    {
        SceneManager.LoadScene(changeScene);
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
