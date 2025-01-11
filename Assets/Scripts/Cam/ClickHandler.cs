using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public Transform spawnPoint;
    public UIManager UImanager;
    public bool isOpenUI = false;
    public GameObject roomObject;

    [SerializeField] private BuildingRoom buildingRoom;
    // Start is called before the first frame update
    public void OpenUI()
    {
        isOpenUI = true;
    }
    public void CloseUI()
    {
        isOpenUI = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            if (EventSystem.current.IsPointerOverGameObject()) {return; }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    // Check if the object hit has the ObjectClickHandler component
                    ClickableObject clickableObject = hit.collider.GetComponent<ClickableObject>();
                    if (clickableObject != null)
                    {
                        spawnPoint = hit.collider.gameObject.transform;
                        Debug.Log(hit.collider.gameObject.name + " tıklandı");
                        roomObject = hit.collider.gameObject;
                        UImanager.room = clickableObject.gameObject.GetComponent<Room>().roomTemplate;
                        UImanager.ToggleRoomUI();
                    }
                    UnlockingFloors unlockingFloors = hit.collider.GetComponent<UnlockingFloors>();
                    if (unlockingFloors != null)
                    {
                        Debug.Log(hit.collider.gameObject.name + " tıklandı");
                        unlockingFloors.unlock();
                    }


                }
            }
        }
    }

}
