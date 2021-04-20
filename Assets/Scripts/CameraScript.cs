using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            /*Debug.Log(Input.GetAxis("Mouse X"));
            float x = Camera.main.transform.position.x + 1f;
            float y = transform.position.y;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z) ;*/

            float x = transform.forward.x;
            float y = transform.position.y;
            float z = transform.position.z;

            transform.position += Camera.main.transform.forward;
        }
    }
}
