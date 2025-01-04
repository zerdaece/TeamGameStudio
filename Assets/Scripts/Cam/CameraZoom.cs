using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera mainCamera;
    private float zoomTarget;
    
    [SerializeField]
    private float zoomMultiplier = 6.0f, minZoom = 1.0f, maxZoom = 10.0f, smoothTime = 0.05f;

    private float velocity = 0.0f;

    [SerializeField]
    private float panSpeed = 10f;

    [SerializeField]
    private float minX = -30f, maxX = 30f, minY = -30f, maxY = 30f;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        zoomTarget = mainCamera.fieldOfView;
    }

    void Update()
    {
        HandleZoom();
        HandlePan();
    }

    private void HandleZoom()
    {
        zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * zoomMultiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);

        mainCamera.fieldOfView = Mathf.SmoothDamp(mainCamera.fieldOfView, zoomTarget, ref velocity, smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
    }

    private void HandlePan()
    {
        if (Input.GetMouseButton(2)) // Middle mouse button
        {
            float moveX = Input.GetAxis("Mouse X") * -panSpeed * Time.unscaledDeltaTime;
            float moveY = Input.GetAxis("Mouse Y") * -panSpeed * Time.unscaledDeltaTime;

            Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }
}
