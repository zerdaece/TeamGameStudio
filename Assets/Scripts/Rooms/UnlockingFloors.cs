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
    

    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
        if (Input.GetMouseButton(0) && !clickHandler.isOpenUI)
        {
            
            clickHandler.OpenUI();
            unlockFloorPopUp.SetActive(true);
            unlockButton = GameObject.Find("UnlockButton");
            resources.TotalRoomCount += 3;
            unlockButton.GetComponent<Button>().onClick.AddListener(() => unlock());
            unlockFloorPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock Floor for " + need + " Goins";
        }
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

    }

}
