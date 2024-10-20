using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera maincamera;
    private float zoomTarget;
    [SerializeField]
    private float multiplier = 2.0f ,   minZoom = 1.0f, maxZoom = 10.0f,smoothTime = 0.1f;
    public float velocity = 0.0f  ;

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        maincamera = GetComponent<Camera>();
        zoomTarget = maincamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        zoomTarget -=  Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);
        maincamera.orthographicSize = Mathf.SmoothDamp(maincamera.orthographicSize, zoomTarget, ref velocity, smoothTime);

        if (Input.GetMouseButton(0))
        {
            float moveX =Input.GetAxis("Mouse X");
            Vector3 movement = new Vector3(moveX, 0, 0);
            transform.position += movement * speed * Time.deltaTime;
        }
    }
}
