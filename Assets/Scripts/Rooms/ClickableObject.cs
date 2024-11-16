using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string roomType= "Generator"; // Spawn edilecek oda türü
    public Vector3 spawnOffset; // Odanın spawn pozisyonu için offset
    private BuildingRoom buildingRoom;

    private void Start()
    {
        // Sahnedeki BuildingRoom scriptini buluyoruz
        buildingRoom = FindObjectOfType<BuildingRoom>();
        if (buildingRoom == null)
        {
            Debug.LogError("BuildingRoom scripti sahnede bulunamadı!");
        }
    }

     void OnMouseDown()
    {
        if (buildingRoom != null)
        {
            // Spawn pozisyonunu hesapla
            Vector3 spawnPosition = transform.position + spawnOffset;
            // BuildingRoom scriptinin SpawnRoom fonksiyonunu çağır
            buildingRoom.SpawnRoom(roomType, spawnPosition);
        }
    }
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
                 if(clickableObject != null)
                 {
                    Vector3 spawnPosition = transform.position + spawnOffset;
                    buildingRoom.SpawnRoom(roomType, spawnPosition);
                 } 
                 else
                 {
                   Debug.Log("Tıklanan obje ClickableObject scriptine sahip degil");
                 }
            
            }
        }
    }

}
