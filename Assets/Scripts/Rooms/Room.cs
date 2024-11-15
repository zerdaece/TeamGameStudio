using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public RoomTemplate roomTemplate;

    public Resources resources;

    public int roomid;

    public float updateInterval = 5f;

    private float timer;

    void Start()
    {
        roomid = roomTemplate.id;
    }

    void Update()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= updateInterval)
        {
            UpdateResources();
            timer = 0f;
        }
    }

    void UpdateResources()
    {
        resources.goins += roomTemplate.goins;
        resources.energy += roomTemplate.energy;
        resources.alcohol += roomTemplate.alcohol;
        resources.coal += roomTemplate.coal;
        resources.dopamin += roomTemplate.dopamin * resources.satisfaction;

        // Kaynakların minimum ve maksimum sınırlarını belirleyebiliriz
        resources.goins = Mathf.Clamp(resources.goins, 0, 100000);
        resources.energy = Mathf.Clamp(resources.energy, 0, 100000);
        resources.alcohol = Mathf.Clamp(resources.alcohol, 0, 100000);
        resources.coal = Mathf.Clamp(resources.coal, 0, 100000);
        resources.dopamin = Mathf.Clamp(resources.dopamin, 0, 100000);
    }
}
