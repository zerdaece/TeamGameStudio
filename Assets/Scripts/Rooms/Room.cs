using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public RoomTemplate roomTemplate;

    public Resources resources;
    public GameObject Customer;

    private int roomid;

    public float updateInterval = 5f;

    private float timer;
    private int newcustomerCount;
    private int customerCount;
    private int maxcustomerCount = 10;

    void Start()
    {
        roomid = roomTemplate.id;
    }

    void Update()
    {
        timer += Time.fixedDeltaTime * Time.timeScale;

        if (timer >= updateInterval)
        {
            GetCustomer();
            UpdateResources();
            timer = 0f;
        }
    }

    void UpdateResources()
    {

        if (
            resources.goins + roomTemplate.goins >= 0 &&
            resources.energy + roomTemplate.energy >= 0 &&
            resources.alcohol + roomTemplate.alcohol >= 0 &&
            resources.coal + roomTemplate.coal >= 0 &&
            resources.dopamin + (roomTemplate.dopamin * resources.satisfaction) >= 0
        )
        {
            resources.goins += roomTemplate.goins;
            resources.energy += roomTemplate.energy;
            resources.alcohol += roomTemplate.alcohol;
            resources.coal += roomTemplate.coal;
            resources.dopamin += roomTemplate.dopamin * resources.satisfaction;
        }
        else
        {
            // Optional: Handle the skipped update case
            Debug.Log("Resource update skipped due to negative result.");
        }

        // Kaynakların minimum ve maksimum sınırlarını belirleme
        resources.goins = Mathf.Clamp(resources.goins, 0, 100000);
        resources.energy = Mathf.Clamp(resources.energy, 0, 100000);
        resources.alcohol = Mathf.Clamp(resources.alcohol, 0, 100000);
        resources.coal = Mathf.Clamp(resources.coal, 0, 100000);
        resources.dopamin = Mathf.Clamp(resources.dopamin, 0, 100000);
    }

    void GetCustomer()
    {

        int dice = Random.Range(1, 7);
        if (newcustomerCount + customerCount < maxcustomerCount)
        {

            newcustomerCount = resources.satisfaction * dice;
            customerCount += newcustomerCount;
            //instantiatecustomer(roomcoordinate, customerCount);
        }



    }
    void instantiatecustomer(/*/roomcoordinate, newcustomerCount/*/)
    {
        int dice = Random.Range(1, 7);
        for (int i = 0; i < customerCount; i++)
        {
            //Instantiate(customer, roomcoordinate, Quaternion.identity);
            //wait(dice);
        }
    }

}
