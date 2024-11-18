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
    

// Soldaki tuşların UI panellerini açması/kapaması

    public void GeneralInfoUIOpen()
    {
        clickHandler.changeboolean();
        generalInfoUIOpen.SetActive(false);
        generalInfoUIClose.SetActive(true);
    }
    public void GeneralInfoUIClose()
    {
        clickHandler.changeboolean();
        generalInfoUIOpen.SetActive(true);
        generalInfoUIClose.SetActive(false);
    }

    public void RoomInfoUIOpen()
    {
        Debug.Log("Room Info UI Open");
        roomInfoUIOpen.SetActive(false);
        roomInfoUIClose.SetActive(true);
        clickHandler.changeboolean();
    }
    public void RoomInfoUIClose()
    {
        roomInfoUIOpen.SetActive(true);
        roomInfoUIClose.SetActive(false);
        clickHandler.changeboolean();
    }

    public void ShopInfoUIOpen()
    {
        shopUIOpen.SetActive(false);
        shopUIClose.SetActive(true);
        clickHandler.changeboolean();
    }
    public void ShopInfoUIClose()
    {
        shopUIOpen.SetActive(true);
        shopUIClose.SetActive(false);
        clickHandler.changeboolean();
    }

    public void ResearchUIOpen()
    {
        researchUIOpen.SetActive(false);
        researchUIClose.SetActive(true);
        clickHandler.changeboolean();
    }
    public void ResearchUIClose()
    {
        researchUIOpen.SetActive(true);
        researchUIClose.SetActive(false);
        clickHandler.changeboolean();
    }
}
