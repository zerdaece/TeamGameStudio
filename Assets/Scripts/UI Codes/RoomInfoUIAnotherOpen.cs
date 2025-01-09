using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomInfoUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject roomInfoUIOpen;
    public GameObject roomInfoUIClose;
    public RoomTemplate room;
    public GameObject RoomName;

    public ClickHandler clickHandler;
    public GameObject closebutton;

    public Resources resources;
    [SerializeField] private GameObject GeneratorButton;
    [SerializeField] private GameObject SpeakEasyButton;
    [SerializeField] private GameObject FarmButton;
    public BuildingRoom buildingRoom;
    [SerializeField] int GeneratorPrice;
    [SerializeField] int SpeakEasyPrice;
    [SerializeField] int FarmPrice;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenRoomUI();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AnotherOpen();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AnotherOpen();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AnotherOpen();
        }
    }

    public void OpenRoomUI()
    {

        if (roomInfoUIOpen.activeSelf && room != null)
        {
            closebutton.SetActive(true);
            clickHandler.OpenUI();
            Debug.Log(clickHandler.isOpenUI);
            print(room.roomType);

            RoomName.GetComponent<TextMeshProUGUI>().text = room.roomType;
            anim.SetTrigger("Open");
            roomInfoUIOpen.SetActive(false);
            roomInfoUIClose.SetActive(true);
        }
        else
        {
            CloseRoomUI();
        }
    }
    void Start()
    {
        room = null;
        anim = GetComponent<Animator>();
        GeneratorButton.GetComponentInChildren<TextMeshProUGUI>().text = "Generator Room Price: " + GeneratorPrice;
        SpeakEasyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Speakeasy Room Price: " + SpeakEasyPrice;
        FarmButton.GetComponentInChildren<TextMeshProUGUI>().text = "Farm Room Price: " + FarmPrice;
    }
    public void AnotherOpen()
    {
        if (roomInfoUIClose.activeSelf)
        {
            anim.SetTrigger("Close");
            roomInfoUIClose.SetActive(false);
            roomInfoUIOpen.SetActive(true);
        }
    }
    public void CloseRoomUI()
    {
        if (closebutton.activeSelf)
        {
            closebutton.SetActive(false);
            clickHandler.CloseUI();
            anim.SetTrigger("Close");
            roomInfoUIClose.SetActive(true);
            roomInfoUIOpen.SetActive(false);
        }
    }
    public void GeneratorButtonClicked()
    {
        if (resources.goins >= GeneratorPrice)
        {
            
            resources.goins -= GeneratorPrice;
            buildingRoom.SpawnRoom("Generator", clickHandler.spawnPoint.position);
            CloseRoomUI();
        }

    }
    public void SpeakEasyButtonClicked()
    {
        if (resources.goins >= SpeakEasyPrice)
        {
            resources.goins -= SpeakEasyPrice;
            buildingRoom.SpawnRoom("SpeakEasy", clickHandler.spawnPoint.position);
            CloseRoomUI();

        }


    }
    public void FarmButtonClicked()
    {
        if (resources.goins >= FarmPrice)
        {
            resources.goins -= FarmPrice;
            buildingRoom.SpawnRoom("Farm", clickHandler.spawnPoint.position);
            CloseRoomUI();

        }
    }
}
