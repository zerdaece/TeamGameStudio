using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    
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
        generalInfoUIOpen.SetActive(false);
        generalInfoUIClose.SetActive(true);
    }
    public void GeneralInfoUIClose()
    {
        generalInfoUIOpen.SetActive(true);
        generalInfoUIClose.SetActive(false);
    }

    public void RoomInfoUIOpen()
    {
        Debug.Log("Room Info UI Open");
        roomInfoUIOpen.SetActive(false);
        roomInfoUIClose.SetActive(true);
    }
    public void RoomInfoUIClose()
    {
        roomInfoUIOpen.SetActive(true);
        roomInfoUIClose.SetActive(false);
    }

    public void ShopInfoUIOpen()
    {
        shopUIOpen.SetActive(false);
        shopUIClose.SetActive(true);
    }
    public void ShopInfoUIClose()
    {
        shopUIOpen.SetActive(true);
        shopUIClose.SetActive(false);
    }

    public void ResearchUIOpen()
    {
        researchUIOpen.SetActive(false);
        researchUIClose.SetActive(true);
    }
    public void ResearchUIClose()
    {
        researchUIOpen.SetActive(true);
        researchUIClose.SetActive(false);
    }
}
