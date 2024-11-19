using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    public ClickHandler clickHandler;
// Soldaki tuşlar
    public GameObject generalInfoUIOpen;
    public GameObject generalInfoUIClose;
    public GameObject roomInfoUIOpen;
    public GameObject roomInfoUIClose;
    public GameObject shopUIOpen;
    public GameObject shopUIClose;
    public GameObject researchUIOpen;
    public GameObject researchUIClose;
    public RoomInfoUIAnotherOpen RoomInfoUIScript;

// Soldaki tuşların UI panellerini açması/kapaması

    public void GeneralInfoUIOpen()
    {
        clickHandler.OpenUI();
        generalInfoUIOpen.SetActive(false);
        generalInfoUIClose.SetActive(true);
    }
    public void GeneralInfoUIClose()
    {
        clickHandler.CloseUI();
        generalInfoUIOpen.SetActive(true);
        generalInfoUIClose.SetActive(false);
    }

    public void RoomInfoUIOpen()
    {
        if(RoomInfoUIScript.room != null)
        {
        clickHandler.OpenUI();
        Debug.Log("Room Info UI Open");
        RoomInfoUIScript.OpenRoomUI();
        }
    }
    public void RoomInfoUIClose()
    {
        clickHandler.CloseUI();
        roomInfoUIOpen.SetActive(true);
        roomInfoUIClose.SetActive(false);
  
    }

    public void ShopInfoUIOpen()
    {
        clickHandler.OpenUI();

        shopUIOpen.SetActive(false);
        shopUIClose.SetActive(true);
  
    }
    public void ShopInfoUIClose()
    {
        clickHandler.CloseUI();
        shopUIOpen.SetActive(true);
        shopUIClose.SetActive(false);
  
    }

    public void ResearchUIOpen()
    {
        clickHandler.OpenUI();

        researchUIOpen.SetActive(false);
        researchUIClose.SetActive(true);
  
    }
    public void ResearchUIClose()
    {
        clickHandler.CloseUI();
        researchUIOpen.SetActive(true);
        researchUIClose.SetActive(false);
  
    }
}
