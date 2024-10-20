using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   public float speed = 5f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(2)){
             float moveX = Input.GetAxisRaw("Mouse X");
             Vector3 movement = new Vector3 (moveX, 0, 0);
             transform.position += movement*speed*Time.deltaTime;
        }
       
    }
}
