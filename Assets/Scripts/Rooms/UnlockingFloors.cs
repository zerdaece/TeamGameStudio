using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class UnlockingFloors : MonoBehaviour
{
    public BuildingRoom buildingRoom;
    public Resources resources;

    public GameObject lockGameObject;//test için
    public GameObject newRooms;
    // Start is called before the first frame update
    [SerializeField] private int need;

    void Update()
    {
    }
    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
        if (Input.GetMouseButton(0))
        {
            //ui açacak

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
                resources.goins -= need;

                Destroy(gameObject);
                Debug.Log("Yeni Odalar Acildi");

            }

    }

}
