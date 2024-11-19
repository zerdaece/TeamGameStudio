using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public Transform spawnPoint;
    public RoomInfoUIAnotherOpen roominfoui;
    public bool isOpenUI = false;
    public GameObject roomObject;

    [SerializeField] private BuildingRoom buildingRoom;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void changeboolean()
    {
        isOpenUI = !isOpenUI;
    }
    public void CloseUI()
    {
        isOpenUI = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isOpenUI) // Left mouse button
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
                    roominfoui.room = clickableObject.gameObject.GetComponent<Room>().roomTemplate;
                    roominfoui.OpenRoomUI();


                }
                else
                {
                    Debug.Log("Tıklanan obje ClickableObject scriptine sahip degil");
                }

            }
        }
    }
    
}
