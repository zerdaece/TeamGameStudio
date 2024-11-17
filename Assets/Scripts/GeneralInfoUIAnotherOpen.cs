using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject generalInfoUIOpen;
    public GameObject generalInfoUIClose;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (generalInfoUIOpen.activeSelf)
            {
                anim.SetTrigger("Open");
                generalInfoUIOpen.SetActive(false);
                generalInfoUIClose.SetActive(true);
            }
            else
            {
                AnotherOpen();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
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
        if (generalInfoUIClose.activeSelf)
        {
            anim.SetTrigger("Close");
            generalInfoUIClose.SetActive(false);
            generalInfoUIOpen.SetActive(true);
        }
    }
}
