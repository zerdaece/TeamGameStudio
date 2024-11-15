using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingFloors : MonoBehaviour
{
    public Resources resources;

    //public GameObject lockGameObject;test için
    // Start is called before the first frame update
    [SerializeField] private int need;

    void unlock()
    {
        if (resources.goins >= need)
        {
            resources.goins -= need;
            Destroy(gameObject);
        }

    }
}
