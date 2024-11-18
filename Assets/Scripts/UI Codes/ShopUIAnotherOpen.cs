using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject shopInfoUIOpen;
    public GameObject shopInfoUIClose;
    public Resources resources;

    public int CoalPrice;
    public int CoalAmount;
    public int AlcoholPrice;
    public int AlcoholAmount;
public ClickHandler clickHandler;
    void Update() 
    {   
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (shopInfoUIOpen.activeSelf)
            {clickHandler.changeboolean();
                anim.SetTrigger("Open");
                shopInfoUIOpen.SetActive(false);
                shopInfoUIClose.SetActive(true);
            }
            else
            {
                clickHandler.changeboolean();
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
    public void BuyCoal()
    {
        if (resources.goins >= CoalPrice)
        {
            resources.goins -= CoalPrice;
            resources.coal += CoalAmount;
        }
    }
    public void BuyAlcohol()
    {
        if (resources.goins >= AlcoholPrice)
        {
            resources.goins -= AlcoholPrice;
            resources.alcohol += AlcoholAmount;
        }
    }
}
