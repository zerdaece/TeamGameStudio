using System.Collections;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnlockingFloors : MonoBehaviour
{
    public Resources resources;

    public ClickHandler clickHandler;
    [SerializeField] private int need;
    public GameObject unlockFloorPopUp;
    public GameObject unlockButton;
    
    void Unlockfloor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
            clickHandler.OpenUI();
            unlockFloorPopUp.SetActive(true);
            
            resources.TotalRoomCount += 3;
            print(resources.TotalRoomCount);
            
            unlockFloorPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock Floor for " + need + " Goins";
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void unlock()
    {

        if (resources.goins >= need)
        {
            unlockFloorPopUp.SetActive(false);
            clickHandler.CloseUI();
            resources.goins -= need;
            Destroy(gameObject);
            Debug.Log("Yeni Odalar Acildi");

        }
        else
        {
            PopUp.ShowPopup("Not enough Goins", "ok","ok",() => Destroy(GameObject.Find("PopUp(Clone)")),() => Destroy(GameObject.Find("PopUp(Clone)")));
        }

    }

}
