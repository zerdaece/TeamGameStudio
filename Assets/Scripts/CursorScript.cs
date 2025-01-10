using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public ParticleSystem cursorParticle;
    void Update()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorParticle.transform.position = new Vector3(cursorPos.x, cursorPos.y, cursorParticle.transform.position.z);
        print(cursorPos);
        if(Input.GetMouseButtonDown(0))
        {
            cursorParticle.Play();
        }
    }
}
