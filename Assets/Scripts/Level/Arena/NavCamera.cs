using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavCamera : MonoBehaviour
{
    // Variables-------------------
    Vector3 pos;
    Vector3 rotation;

    float speed = 10.0f; 
    public float centerX = 0f;
    public float centerZ = 0f;

    protected float fDistance = 1;
    protected float fSpeed = 1;

    // ---------------------

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        pos = new Vector3(0.0f, 5.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate 
        if (Input.GetKey(KeyCode.RightArrow)) // right
            transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.Self); // speed degrees per second
        if (Input.GetKey(KeyCode.LeftArrow)) // left
            transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self); // rotate around negative y-axis
        if (Input.GetKey(KeyCode.UpArrow)) // up
            transform.Rotate(-speed * Time.deltaTime, 0.0f, 0.0f, Space.Self); // rotate around negative x-axis
        if (Input.GetKey(KeyCode.DownArrow)) // down
            transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f, Space.Self);

        // Move
        if (Input.GetKey(KeyCode.W)) // up
            transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.A)) // left
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.S)) // down
            transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.D)) // right
            transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
        
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKey(KeyCode.W)) { // forward
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.S)) { // backward
                transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.Self);
            }
        }

        // Fix axis
        if (Input.GetKey(KeyCode.Space))
            transform.rotation = Quaternion.identity;
    }
}
