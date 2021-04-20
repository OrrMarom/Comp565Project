using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>(); 

    void Start()
    {
        // spawns an existing prefab layout
        GameObject spawn = spawnList[Random.Range(0, spawnList.Count)]; // select random layout
        Instantiate(spawn, transform.position, Quaternion.identity); // spawn prefab 
        Destroy(gameObject); // destroy this gameObject
    }
}