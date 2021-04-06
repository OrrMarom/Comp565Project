using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float speed;
    public float bulletSpeed;
    Rigidbody rb;

    GameObject prefabBullet;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        prefabBullet = Resources.Load("Bullet") as GameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefabBullet) as GameObject;
            GameObject hiddenBullet = GameObject.Find("hiddenBullet");
            /*float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z - 2f;*/
            float x = hiddenBullet.transform.position.x;
            float y = hiddenBullet.transform.position.y;
            float z = hiddenBullet.transform.position.z;

            //            bullet.transform.position = transform.position + transform.forward * (-2f);

            bullet.transform.rotation = hiddenBullet.transform.rotation;

            bullet.transform.position = new Vector3(x, y, z);

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = (-1) * transform.forward * bulletSpeed;
            audioSource.Play();

            // Add bullet collision
            bullet.AddComponent<DestroyCubes>();
        }
    }
}
