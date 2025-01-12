using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public ParticleSystem cursorParticle;
    void Update()
    {
        Vector3 CursorPos = (Vector3)Input.mousePosition;
        CursorPos.z = 4.0f;
        cursorParticle.transform.position = Camera.main.ScreenToWorldPoint(CursorPos);
        print(CursorPos);
        if (Input.GetMouseButtonDown(0))
        {
            cursorParticle.Play();
        }
    }
}
