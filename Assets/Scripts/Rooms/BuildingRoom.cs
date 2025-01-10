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
    public Resources resources;

    public Dictionary<string, GameObject> roomPrefabs;

    private void Start()
    {
        // BU KISIMDAKİ PREFABLARIN İSİMLERİNİN DOĞRU OLMASINA DİKKAT ETMEK LAZIM -bağırmama gerek yoktu ama- -göktuğ-
      /*/  roomPrefabs = new Dictionary<string, GameObject>
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
        /*/
    }
    public void SpawnRoom(RoomTemplate roomType, Vector3 spawnPosition)
    {


        Instantiate(roomType.roomPrefab, spawnPosition, Quaternion.identity);
    }

}

