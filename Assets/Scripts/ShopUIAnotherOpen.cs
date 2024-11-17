using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject shopInfoUIOpen;
    public GameObject shopInfoUIClose;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (shopInfoUIOpen.activeSelf)
            {
                anim.SetTrigger("Open");
                shopInfoUIOpen.SetActive(false);
                shopInfoUIClose.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.E))
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
        if (shopInfoUIClose.activeSelf)
        {
            anim.SetTrigger("Close");
            shopInfoUIClose.SetActive(false);
            shopInfoUIOpen.SetActive(true);
        }
    }
}
