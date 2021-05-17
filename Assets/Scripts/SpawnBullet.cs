using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;

    public List<GameObject> Gun = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);

            if (Gun != null)
            {
                vfx.transform.localRotation = Gun[0].transform.rotation;
            } 
            else
            {
                Debug.Log("Assign size 1 adn 'HandGun_01' from the Hierarchy to the SpawnBullet in the array named 'Gun'");
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
