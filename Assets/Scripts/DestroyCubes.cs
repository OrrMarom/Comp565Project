using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    //Used with bullets, not currently used in raycast approach
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DestructableCube")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Hit cube at " + collision.gameObject.transform.position);
            GameObject g = collision.gameObject;
        }
    }
}
