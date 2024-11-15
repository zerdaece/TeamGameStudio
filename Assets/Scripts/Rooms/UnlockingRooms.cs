using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingRooms : MonoBehaviour
{
   public Resources resources;
    public bool isLocked = true;
    //public GameObject lockGameObject;test için
    // Start is called before the first frame update
    [SerializeField] private int need;
    
    void unlock()
    {
        if (isLocked && resources.goins >= need)
        {
            resources.goins -= need;
            isLocked = false;
            //Destroy(lockGameObject);// test edilcek
        }
        isLocked = false;
    }
}
