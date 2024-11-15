using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRoom : MonoBehaviour
{ 
    
    public GameObject speakeasyPrefab;
    public GameObject generatorRoomPrefab;
    public GameObject distillerRoomPrefab;
    public GameObject accommodationPrefab;

    private Dictionary<string, GameObject> roomPrefabs;

    private void Start()
    {
        roomPrefabs = new Dictionary<string, GameObject>
        {
            { "Speakeasy", speakeasyPrefab },
            { "Generator", generatorRoomPrefab },
            { "Distiller", distillerRoomPrefab },
            { "Accommodation", accommodationPrefab }
        };
    }

    public void SpawnRoom(string roomType, Vector3 spawnPosition)
    {
        if (roomPrefabs.ContainsKey(roomType))
        {
            Instantiate(roomPrefabs[roomType], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Geçersiz oda türü!");
        }
    }
}

