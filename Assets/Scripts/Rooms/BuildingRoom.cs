using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRoom : MonoBehaviour
{
    public Button GeneratorButton;
    public Button FarmButton;
    public Button SpeakeasyButton;  
    public GameObject speakeasyPrefab;
    public GameObject generatorRoomPrefab;
    public GameObject distillerRoomPrefab;
    public GameObject accommodationPrefab;
    public GameObject farmPrefab;

    public Dictionary<string, GameObject> roomPrefabs;

    private void Start()
    {
        roomPrefabs = new Dictionary<string, GameObject>
       {
        { "Speakeasy", speakeasyPrefab },
        { "Generator", generatorRoomPrefab },
       // { "Distiller", distillerRoomPrefab },
        //{ "Accommodation", accommodationPrefab },
        {"Farm", farmPrefab }
      
       };
        foreach (var entry in roomPrefabs)
        {
            Debug.Log($"Room Type: {entry.Key}, Prefab: {entry.Value}");
        }
    }
    public void SpawnRoom(string roomType, Vector3 spawnPosition)
    {
        
        
        if (roomPrefabs.ContainsKey(roomType))
        {
            Instantiate(roomPrefabs[roomType], spawnPosition, Quaternion.identity);
            Debug.Log($"Instantiated {roomType} at {spawnPosition}");
            Destroy(gameObject.GetComponent<ClickHandler>().roomObject);
        }
        else
        {
            Debug.LogWarning($"Invalid room type: {roomType}");
        }
    }
    
}

