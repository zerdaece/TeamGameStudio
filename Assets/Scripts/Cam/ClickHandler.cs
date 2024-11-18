using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public Transform spawnPoint;
    public RoomInfoUIAnotherOpen roominfoui;
    public Boolean isOpenUI = false;
    [SerializeField]private BuildingRoom buildingRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !isOpenUI ) // Left mouse button
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               if(hit.collider.name == "Lock")
                {
                     UnlockingFloors unlockingFloors = hit.collider.GetComponent<UnlockingFloors>();
                     unlockingFloors.unlock();
                }
                // Check if the object hit has the ObjectClickHandler component
                 ClickableObject clickableObject = hit.collider.GetComponent<ClickableObject>();
                 if(clickableObject !=null)
                 {
                    spawnPoint= hit.collider.gameObject.transform  ;
                    Debug.Log(hit.collider.gameObject.name + " tıklandı");

                    roominfoui.room = clickableObject.gameObject.GetComponent<Room>().roomTemplate;
                    roominfoui.OpenRoomUI();
                    Vector3 spawnPosition = clickableObject.gameObject.transform.position ;

                 } 
                 else
                 {
                   Debug.Log("Tıklanan obje ClickableObject scriptine sahip degil");
                 }
            
            }
        }
    }
}
