using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;

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

    public BuildingRoom buildingRoom;
    public ClickHandler clickHandler;
    public GameObject upgradelist;
    public GameObject upgradelistitem;
    public GameObject researchlist;
    public GameObject researchlistitem;
    public RoomTemplate room;
    public TextMeshProUGUI roomName;
    public Relations relations;
    bool isPaused = false;
    int gameSpeed;
    private bool isQuestsUIOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ToggleRoomUI();
            // isRoomInfoUIOpen = !isRoomInfoUIOpen;
        }

        // General Info UI Aç/Kapa (Q Tuşu)
        if (Input.GetKeyDown(KeyCode.Q))
        {

            ToggleGeneralInfo();
            //isGeneralInfoUIOpen = !isGeneralInfoUIOpen;
        }

        // Research Info UI Aç/Kapa (E Tuşu)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleResearchUI();
            // isResearchInfoUIOpen = !isResearchInfoUIOpen;
        }

        // Shop UI Aç/Kapa (R Tuşu)
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleShopUI();
            // isShopUIOpen = !isShopUIOpen;
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
    private void GeneralInfoOpen()
    {
        print("a");
        isGeneralInfoUIOpen = true;
        GeneralInfoUIAnimator.SetTrigger("Open");



    }
    private void RoomInfoUIOpen()
    {

        if (room != null)
        {
            foreach (Transform child in upgradelist.transform)
            {
                Destroy(child.gameObject);
            }
            RoomInfoUIAnimator.SetTrigger("Open");
            isRoomInfoUIOpen = true;
            print(isRoomInfoUIOpen);
            roomName.text = room.Name;
            foreach (Research research in room.Researches)
            {
                /*
                    GameObject item = Instantiate(researchlistitem, researchlist.transform);
                    item.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
                    {if (resources.dopamin >= research.dopamin) { resources.dopamin -= research.dopamin; 
                    room.Researches.Remove(research); 
                    room.goins += research.goins;
                    room.energy += research.energy;
                    room.alcohol += research.alcohol;
                    room.coal += research.coal;
                    room.satisfaction += research.satisfaction;
                    if (research.roomTemplate != null)
                    {room.Roomupdates.Add(research.roomTemplate);}
                */


            }
            foreach (RoomTemplate upgraderoom in room.RoomUpdates)
            {

                GameObject item = Instantiate(upgradelistitem, upgradelist.transform);
                item.transform.name = upgraderoom.Name;
                item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = upgraderoom.Name;
                item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = upgraderoom.Description;
                item.transform.Find("Button").transform.Find("Buy").GetComponent<TextMeshProUGUI>().text = upgraderoom.price.ToString();
                item.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
        {
            // Check if the player has enough resources
            if (resources.goins >= upgraderoom.price)
            {
                // Deduct the price from the player's resources
                resources.goins -= upgraderoom.price;
                resources.satisfaction -= room.satisfaction;
                resources.satisfaction += upgraderoom.satisfaction;
                // Spawn the upgraderoom prefab
                Instantiate(upgraderoom.roomPrefab, clickHandler.spawnPoint.position, Quaternion.identity);
                PopUp.ShowPopup($"{upgraderoom.Name} purchased! Remaining goins: {resources.goins}", "OK", "Cancel", () => Destroy(GameObject.Find("PopUp(Clone)")), () => Destroy(GameObject.Find("PopUp(Clone)")));
                Debug.Log($"{upgraderoom.Name} purchased! Remaining goins: {resources.goins}");
                ToggleRoomUI();

                foreach (var npcRelation in room.npcrelationchange)
                {
                    relations.ModifyRelation(npcRelation.npc.name, npcRelation.relationChange);
                }
            }
            else
            {
                Debug.Log("Not enough resources to buy this upgrade!");
            }
        });
            }
        }

    }
    private void ResearchInfoUIOpen()
    {
        isResearchInfoUIOpen = true;
        ResearchInfoUIAnimator.SetTrigger("Open");
        Debug.Log("opening Research UI");

    }
    private void ShopUIOpen()
    {
        isShopUIOpen = true;
        ShopUIAnimator.SetTrigger("Open");
        Debug.Log("Opening Shop UI");

    }
    private void QuestsUIOpen()
    {
        isQuestsUIOpen = true;
    }
    private void RoomInfoUIClose()
    {
        print(isRoomInfoUIOpen);
        isRoomInfoUIOpen = false;
        RoomInfoUIAnimator.SetTrigger("Close");
        Debug.Log("Room Info UI Closed");
    }
    private void CloseAllPanels()
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


    private void GeneralInfoUIClose()
    {
        Debug.Log("General Info UI Closed");
        isGeneralInfoUIOpen = false;

        GeneralInfoUIAnimator.SetTrigger("Close");

    }

    // Research Info UI'yi kapatma metodu.
    private void ResearchInfoUIClose()
    {
        ResearchInfoUIAnimator.SetTrigger("Close");
        Debug.Log("Research Info UI Closed");
    }

    // Shop UI'yi kapatma metodu.
    private void ShopUIClose()
    {
        ShopUIAnimator.SetTrigger("Close");
        Debug.Log("Shop UI Closed");
    }
    private void QuestsUIClose()
    {
        isQuestsUIOpen = true;
    }
    public void ToggleGeneralInfo()
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
    }
    public void ToggleShopUI()
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
    }
    public void ToggleRoomUI()
    {
        if (isRoomInfoUIOpen)
        {
            RoomInfoUIClose();
        }
        else
        {
            CloseAllPanels();
            RoomInfoUIOpen();
        }
    }
    public void ToggleResearchUI()
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
    }
    public void ToggleQuestsUI()
    {
        if (isQuestsUIOpen)
        {
            QuestsUIClose();
        }
        else
        {
            CloseAllPanels();
            QuestsUIOpen();
        }



    }


}
