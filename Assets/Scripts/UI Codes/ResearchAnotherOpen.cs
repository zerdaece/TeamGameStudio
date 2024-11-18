using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject researchInfoUIOpen;
    public GameObject researchInfoUIClose;
    public ClickHandler clickHandler;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (researchInfoUIOpen.activeSelf)
            {
                clickHandler.changeboolean();
                anim.SetTrigger("Open");
                researchInfoUIOpen.SetActive(false);
                researchInfoUIClose.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.R))
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
        if (researchInfoUIClose.activeSelf)
        {
            anim.SetTrigger("Close");
            researchInfoUIClose.SetActive(false);
            researchInfoUIOpen.SetActive(true);
        }
    }
}
