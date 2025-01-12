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
    public List<Research> researches;
    public GameObject roomprefab;
    bool isPaused = false;
    public float timer;
    public float updateInterval = 5f;
    int gameSpeed;
    private bool isQuestsUIOpen;


    private int lastGoins = 0;
    private int lastEnergy = 0;
    private int lastAlcohol = 0;
    private int lastCoal = 0;
    private int lastDopamin = 0;
    private int differenceGoins;
    private int differenceEnergy;
    private int differenceAlcohol;
    private int differenceCoal;
    private int differenceDopamin;
    [SerializeField] private GameObject resourceText;
    void Update()
    {

        timer += Time.fixedDeltaTime * Time.timeScale;

        if (timer >= updateInterval)
        {
            UpdateResources();
            timer = 0f;

        }
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
    private void UpdateResources()
    {
        differenceGoins = resources.goins - lastGoins;
        differenceEnergy = resources.energy - lastEnergy;
        differenceAlcohol = resources.alcohol - lastAlcohol;
        differenceCoal = resources.coal - lastCoal;
        differenceDopamin = resources.dopamin - lastDopamin;
        resourceText.GetComponent<TextMeshProUGUI>().text = "Goins: " + resources.goins + " (+" + differenceGoins + ")" + "\n" +
            "Energy: " + resources.energy + " (" + differenceEnergy + ")" + "\n" +
            "Alcohol: " + resources.alcohol + " (" + differenceAlcohol + ")" + "\n" +
            "Coal: " + resources.coal + " (" + differenceCoal + ")" + "\n" +
            "Dopamin: " + resources.dopamin + " (+" + differenceDopamin + ")";
        lastGoins = resources.goins;
        lastEnergy = resources.energy;
        lastAlcohol = resources.alcohol;
        lastCoal = resources.coal;
        lastDopamin = resources.dopamin;
    }
    private void GeneralInfoOpen()
    {

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

            foreach (RoomTemplate upgraderoom in room.RoomUpdates)
            {
                GameObject item = Instantiate(upgradelistitem, upgradelist.transform);

                // Create a local copy of upgraderoom
                RoomTemplate currentRoom = upgraderoom;
                item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = currentRoom.Name;
                item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = currentRoom.Description;
                item.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = currentRoom.price.ToString();
                item.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
                {
                    // Check if the player has enough resources
                    if (resources.goins >= currentRoom.price)
                    {
                        // Deduct the price from the player's resources
                        resources.goins -= currentRoom.price;

                        // Logic for upgrading the room
                        resources.satisfaction -= room.satisfaction;
                        resources.satisfaction += currentRoom.satisfaction;

                        // Spawn the upgraded room prefab
                        Instantiate(currentRoom.roomPrefab, clickHandler.spawnPoint.position, Quaternion.identity);
                        Destroy(roomprefab);

                        PopUp.ShowPopup($"{currentRoom.Name} purchased! Remaining goins: {resources.goins}", "OK", "close",
                            () => Destroy(GameObject.Find("PopUp(Clone)")),
                            () => Destroy(GameObject.Find("PopUp(Clone)")));

                        Debug.Log($"{currentRoom.Name} purchased! Remaining goins: {resources.goins}");
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
        foreach (Transform child in researchlist.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Research research in researches)
        {

            GameObject item = Instantiate(researchlistitem, researchlist.transform);
            item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = research.Name;
            item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = research.Description;
            item.transform.Find("Button").GetComponentInChildren<TextMeshProUGUI>().text = string.Format("Price: " + research.dopamin);
            item.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (resources.dopamin >= research.dopamin)
                {
                    resources.dopamin -= research.dopamin;
                    research.roomTemplate.goins += research.goins;
                    research.roomTemplate.energy += research.energy;
                    research.roomTemplate.alcohol += research.alcohol;
                    research.roomTemplate.coal += research.coal;
                    research.roomTemplate.satisfaction += research.satisfaction;
                    if (research.AddRoomTemplate != null)
                    {
                        research.AddTo.RoomUpdates.Add(research.AddRoomTemplate);
                    }
                    PopUp.ShowPopup($"researched! Remaining Dopamine: {resources.dopamin}", "OK", "close", () => Destroy(GameObject.Find("PopUp(Clone)")), () => Destroy(GameObject.Find("PopUp(Clone)")));

                    researches.Remove(research);
                }
                Debug.Log("opening Research UI");

            });
        }
    }
    private void ShopUIOpen()
    {
        isShopUIOpen = true;
        ShopUIAnimator.SetTrigger("Open");
        Debug.Log("Opening Shop UI");

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
        isResearchInfoUIOpen = false;
    }

    // Shop UI'yi kapatma metodu.
    private void ShopUIClose()
    {
        ShopUIAnimator.SetTrigger("Close");
        Debug.Log("Shop UI Closed");
        isShopUIOpen = false;
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



}
