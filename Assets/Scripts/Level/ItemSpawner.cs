using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();

    float dpsYAxis = 30.0f; // dps = degrees per second; rotate around Y-Axis
    float dpsXAxis = 20.0f;
    float amplitude = 0.5f;
    float frequency = 1.0f;


    void Start()
    {
        GameObject spawn = itemList[Random.Range(0, itemList.Count)];
        GameObject item = Instantiate(spawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update() 
    {
        transform.Rotate(new Vector3(Time.deltaTime * dpsXAxis, Time.deltaTime * dpsYAxis, 0.0f), Space.World);
    }
}
