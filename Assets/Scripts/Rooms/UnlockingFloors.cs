using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingFloors : MonoBehaviour
{
    public Resources resources;
    private bool isLocked = true;
    // Start is called before the first frame update
    [SerializeField] private int need;

    void unlock()
    {
        if (isLocked && resources.goins >= need)
        {
            resources.goins -= need;
            Destroy(gameObject);
        }
    }

}
