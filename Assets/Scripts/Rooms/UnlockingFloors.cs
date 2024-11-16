using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class UnlockingFloors : MonoBehaviour
{
    // public Resources resources;

    public GameObject lockGameObject;//test için
    public GameObject newRooms;
    // Start is called before the first frame update
    [SerializeField] private int need;
    
    void Update()
{
    unlock();
}    
     void OnMouseOver()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
            if (Input.GetMouseButton(0))
                {
                   //ui açacak
     
               }
        }
        void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;   
        }

    void unlock()
    {
       // if (resources.goins >= need)
       if (Input.GetKeyDown(KeyCode.Space))//test için
        {
           //resources.goins -= need;
           
            Destroy(gameObject);
            
        }

    }
    
}
