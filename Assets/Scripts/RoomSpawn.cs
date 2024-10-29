using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
   
    public GameObject mainRoom;      // Ana oda referansı
    public GameObject roomPrefab;    // Eklenecek oda prefabı
    private GameObject lastRoom;     // En son eklenen oda

    void Start()
    {
        // Oyunun başında ana odayı referans olarak alıyoruz
        lastRoom = mainRoom;
       
    }

    void Update()
    {
        // Space tuşuna basıldığında yeni oda ekle
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRoom();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(lastRoom);
           
        }
    }

    void SpawnRoom()
    {
        // 

        // Yeni odanın pozisyonu, en son eklenen odanın sağında olacak şekilde ayarlanıyor
        Vector3 newPosition = lastRoom.transform.position + new Vector3(lastRoom.transform.localScale.x+6.6f, 0, 0);
        
        
        // Yeni odayı oluştur ve pozisyonunu ayarla
        lastRoom = Instantiate(roomPrefab, newPosition, Quaternion.identity);
    }
}