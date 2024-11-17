using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfoUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject roomInfoUIOpen;
    public GameObject roomInfoUIClose;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (roomInfoUIOpen.activeSelf)
            {
                anim.SetTrigger("Open");
                roomInfoUIOpen.SetActive(false);
                roomInfoUIClose.SetActive(true);
            }
            else
            {
                AnotherOpen();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AnotherOpen();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AnotherOpen();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AnotherOpen();
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AnotherOpen()
    {
        if (roomInfoUIClose.activeSelf)
        {
            anim.SetTrigger("Close");
            roomInfoUIClose.SetActive(false);
            roomInfoUIOpen.SetActive(true);
        }
    }
}
