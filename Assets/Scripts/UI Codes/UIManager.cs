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
    [Header("PanelAnimators")]
    public Animator RoomInfoUIAnimator;
    public Animator GeneralInfoUIAnimator;
    public Animator ResearchInfoUIAnimator;
    public Animator ShopUIAnimator;
    [Header("PanelBooleans")]
    public bool isRoomInfoUIOpen;
    public bool isGeneralInfoUIOpen;
    public bool isResearchInfoUIOpen;
    public bool isShopUIOpen;
    
    public ClickHandler clickHandler;
    public GameObject upgradelist;
    public GameObject upgradelistitem;
    public RoomTemplate room;
    public TextMeshProUGUI roomName;
    bool isPaused = false;
    int gameSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isRoomInfoUIOpen)
            {
                RoomInfoUIClose();
            }
            else
            {
                CloseAllPanels(); // Diğer panelleri kapatır.
                RoomInfoUIOpen();
            }
            isRoomInfoUIOpen = !isRoomInfoUIOpen;
        }

        // General Info UI Aç/Kapa (Q Tuşu)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isGeneralInfoUIOpen)
            {
                GeneralInfoUIClose();
            }
            else
            {
                CloseAllPanels();
                GeneralInfoOpen();
            }
            //isGeneralInfoUIOpen = !isGeneralInfoUIOpen;
        }

        // Research Info UI Aç/Kapa (E Tuşu)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isResearchInfoUIOpen)
            {
                ResearchInfoUIClose();
            }
            else
            {
                CloseAllPanels();
                ResearchInfoUIOpen();
            }
            isResearchInfoUIOpen = !isResearchInfoUIOpen;
        }

        // Shop UI Aç/Kapa (W Tuşu)
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isShopUIOpen)
            {
                ShopUIClose();
            }
            else
            {
                CloseAllPanels();
                ShopUIOpen();
            }
            isShopUIOpen = !isShopUIOpen;
        }

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
        for (int i = 0; i < MoneyText.Length; i++)
        {
            MoneyText[i].text = _money;
        }
        for (int i = 0; i < DopamineText.Length; i++)
        {
            DopamineText[i].text = _dopamine;
        }
        for (int i = 0; i < CoalText.Length; i++)
        {
            CoalText[i].text = _coal;
        }
        for (int i = 0; i < AlcoholText.Length; i++)
        {
            AlcoholText[i].text = _alcohol;
        }
        for (int i = 0; i < EnergyText.Length; i++)
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
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void FastForward4x()
    {
        if (Time.timeScale == 1f || Time.timeScale == 8f)
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
        if (Time.timeScale == 1f || Time.timeScale == 4f)
        {
            Time.timeScale = 8f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void GeneralInfoOpen()
    {
        print("a");
        isGeneralInfoUIOpen = true;
        GeneralInfoUIAnimator.SetTrigger("Open");
        /* RoomInfoUIAnimator.SetTrigger("Close");
         ResearchInfoUIAnimator.SetTrigger("Close");
         ShopUIAnimator.SetTrigger("Close");*/


    }
    public void RoomInfoUIOpen()
    {
        if(room.roomType)
        //GeneralInfoUIAnimator.SetTrigger("Close");
        RoomInfoUIAnimator.SetTrigger("Open");
        // ResearchInfoUIAnimator.SetTrigger("Close");
        // ShopUIAnimator.SetTrigger("Close");

    }
    public void ResearchInfoUIOpen()
    {

        //GeneralInfoUIAnimator.SetTrigger("Close");
        //RoomInfoUIAnimator.SetTrigger("Close");
        ResearchInfoUIAnimator.SetTrigger("Open");
        //ShopUIAnimator.SetTrigger("Close");
        Debug.Log("opening Research UI");

    }
    public void ShopUIOpen()
    {

        //GeneralInfoUIAnimator.SetTrigger("Close");
        //RoomInfoUIAnimator.SetTrigger("Close");
        //ResearchInfoUIAnimator.SetTrigger("Close");
        ShopUIAnimator.SetTrigger("Open");
        Debug.Log("Opening Shop UI");

    }
    void RoomInfoUIClose()
    {
        RoomInfoUIAnimator.SetTrigger("Close");
        Debug.Log("Room Info UI Closed");
    }
    public void CloseAllPanels()
    {
        if (isRoomInfoUIOpen)
        {
            RoomInfoUIClose();
            isRoomInfoUIOpen = false;
        }
        if (isGeneralInfoUIOpen)
        {
            isGeneralInfoUIOpen = false;

            GeneralInfoUIClose();
        }
        if (isResearchInfoUIOpen)
        {
            ResearchInfoUIClose();
            isResearchInfoUIOpen = false;
        }
        if (isShopUIOpen)
        {
            ShopUIClose();
            isShopUIOpen = false;
        }
    }


    void GeneralInfoUIClose()
    {
        Debug.Log("General Info UI Closed");
        isGeneralInfoUIOpen = false;

        GeneralInfoUIAnimator.SetTrigger("Close");

    }

    // Research Info UI'yi kapatma metodu.
    void ResearchInfoUIClose()
    {
        ResearchInfoUIAnimator.SetTrigger("Close");
        Debug.Log("Research Info UI Closed");
    }

    // Shop UI'yi kapatma metodu.
    void ShopUIClose()
    {
        ShopUIAnimator.SetTrigger("Close");
        Debug.Log("Shop UI Closed");
    }


}
