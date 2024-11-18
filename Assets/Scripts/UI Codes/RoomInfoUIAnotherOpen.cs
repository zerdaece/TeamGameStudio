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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (room != null)
            {

            }
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

        if (roomInfoUIOpen.activeSelf)
        { clickHandler.isOpenUI = !clickHandler.isOpenUI; 
        Debug.Log(clickHandler.isOpenUI);
            print(room.roomType);
            RoomName.GetComponent<TextMeshProUGUI>().text = room.roomType;
            anim.SetTrigger("Open");
            roomInfoUIOpen.SetActive(false);
            roomInfoUIClose.SetActive(true);
        }
        else
        {
            AnotherOpen();
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
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
}
