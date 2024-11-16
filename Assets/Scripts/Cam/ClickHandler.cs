using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    [SerializeField]private BuildingRoom buildingRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               
                // Check if the object hit has the ObjectClickHandler component
                 ClickableObject clickableObject = hit.collider.GetComponent<ClickableObject>();
                 if(clickableObject !=null)
                 {
                    Debug.Log(gameObject.name + " tıklandı");
                    Vector3 spawnPosition = clickableObject.gameObject.transform.position + clickableObject.spawnOffset;
                    buildingRoom.SpawnRoom(clickableObject.roomType, spawnPosition);
                 } 
                 else
                 {
                   Debug.Log("Tıklanan obje ClickableObject scriptine sahip degil");
                 }
            
            }
        }
    }
}
