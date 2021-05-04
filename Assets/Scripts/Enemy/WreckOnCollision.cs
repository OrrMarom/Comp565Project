using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckOnCollision : MonoBehaviour
{
    public GameObject wreckedVersion;

    // TODO: Trigger when chicken.health == 0.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent(typeof(PlayerController))) {
            Destroy(this.gameObject);
            Instantiate(wreckedVersion, transform.position, transform.rotation);
        }
        
    }
}
