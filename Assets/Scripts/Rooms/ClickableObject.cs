using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string roomType; // Spawn edilecek oda türü
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

     /*/void OnMouseDown()
    {
        if (buildingRoom != null)
        {
            // Spawn pozisyonunu hesapla
            Vector3 spawnPosition = transform.position + spawnOffset;
            // BuildingRoom scriptinin SpawnRoom fonksiyonunu çağır
            buildingRoom.SpawnRoom(roomType, spawnPosition);
        }
    }/*/


}
