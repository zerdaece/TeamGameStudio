using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResearchUIAnotherOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject generalInfoUIOpen;
    public GameObject generalInfoUIClose;
    public ClickHandler clickHandler;
    public Resources resources;
    public float timer;
    public float updateInterval = 5f;
    private int lastGoins = 0;
    private int lastEnergy = 0;
    private int lastAlcohol = 0;
    private int lastCoal = 0;
    private int lastDopamin = 0;
    private int differenceGoins;
    private int differenceEnergy;
    private int differenceAlcohol;
    private int differenceCoal;
    private int differenceDopamin;
    [SerializeField] private GameObject resourceText;

    private void UpdateResources()
    {
        differenceGoins = resources.goins - lastGoins;
        differenceEnergy = resources.energy - lastEnergy;
        differenceAlcohol = resources.alcohol - lastAlcohol;
        differenceCoal = resources.coal - lastCoal;
        differenceDopamin = resources.dopamin - lastDopamin;
        resourceText.GetComponent<TextMeshProUGUI>().text = "Goins: " + resources.goins + " (+" + differenceGoins + ")" + "\n" +
            "Energy: " + resources.energy + " (+" + differenceEnergy + ")" + "\n" +
            "Alcohol: " + resources.alcohol + " (+" + differenceAlcohol + ")" + "\n" +
            "Coal: " + resources.coal + " (+" + differenceCoal + ")" + "\n" +
            "Dopamin: " + resources.dopamin + " (+" + differenceDopamin + ")";
        lastGoins = resources.goins;
        lastEnergy = resources.energy;
        lastAlcohol = resources.alcohol;
        lastCoal = resources.coal;
        lastDopamin = resources.dopamin;
    }


    void Update()
    {

        timer += Time.fixedDeltaTime * Time.timeScale;

        if (timer >= updateInterval)
        {
            UpdateResources();
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (generalInfoUIOpen.activeSelf)
            {
                clickHandler.changeboolean();
                anim.SetTrigger("Open");
                generalInfoUIOpen.SetActive(false);
                generalInfoUIClose.SetActive(true);
            }
            else
            {
                clickHandler.changeboolean();
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
