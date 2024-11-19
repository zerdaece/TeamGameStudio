using System.Collections;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class UnlockingFloors : MonoBehaviour
{
    public Resources resources;

    public GameObject lockGameObject;
    public ClickHandler clickHandler;
    [SerializeField] private int need;
    public GameObject unlockFloorPopUp;

    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
        if (Input.GetMouseButton(0))
        {
            clickHandler.changeboolean();
            unlockFloorPopUp.SetActive(true);
            unlockFloorPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock Floor for " + need + " Coins";
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
            clickHandler.changeboolean();
            resources.goins -= need;

            Destroy(gameObject);
            Debug.Log("Yeni Odalar Acildi");

        }

    }

}
