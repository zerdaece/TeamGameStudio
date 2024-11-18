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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenRoomUI();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CloseRoomUI();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CloseRoomUI();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            CloseRoomUI();
        }
    }

    public void OpenRoomUI()
    {

        if (roomInfoUIOpen.activeSelf && room != null)
        {
            closebutton.SetActive(true);
            clickHandler.changeboolean();
            Debug.Log(clickHandler.isOpenUI);
            print(room.roomType);
            RoomName.GetComponent<TextMeshProUGUI>().text = room.roomType;
            anim.SetTrigger("Open");
            roomInfoUIOpen.SetActive(false);
            roomInfoUIClose.SetActive(true);
        }
        else
        {
            clickHandler.changeboolean();
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
    public void CloseRoomUI()
    {
        if(closebutton.activeSelf)
        {
            closebutton.SetActive(false);
            clickHandler.changeboolean();
            anim.SetTrigger("Close");
            roomInfoUIClose.SetActive(false);
            roomInfoUIOpen.SetActive(true);
        }
}
}
