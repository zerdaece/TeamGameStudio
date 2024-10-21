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

    public float minX= -30f, maxX = 30f, minY = -30f, maxY = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        maincamera = GetComponent<Camera>();
        zoomTarget = maincamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        zoomTarget -=  Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);
        maincamera.fieldOfView = Mathf.SmoothDamp(maincamera.fieldOfView, zoomTarget, ref velocity, smoothTime);

        if (Input.GetMouseButton(0))
        {
            float moveX =Input.GetAxis("Mouse X");
            Vector3 movement = new Vector3(moveX, 0, 0);
            transform.position += movement*(-1) * speed * Time.deltaTime;

            float moveY = Input.GetAxis("Mouse Y");
            Vector3 movement2 = new Vector3(0, moveY, 0);
            transform.position += movement2 * (-1) * speed * Time.deltaTime;


            Vector3 clampPosition=transform.position;
            clampPosition.x = Mathf.Clamp(transform.position.x, minX, maxX);
            clampPosition.y = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = clampPosition;
        }
    }
}
