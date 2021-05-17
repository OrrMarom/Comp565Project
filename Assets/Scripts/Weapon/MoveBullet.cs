using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet: MonoBehaviour
{
    public float speed;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {

        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 5);
    }
}
