using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    Vector3 stageCenter = new Vector3(0, 15, 0);

    void Start()
    {
        Vector3 relativePos = stageCenter - transform.position;
        GameObject newTarget = Instantiate(target, transform.position, Quaternion.LookRotation(relativePos, Vector3.forward));
        newTarget.AddComponent<TargetBehavior>();
        Destroy(gameObject);
    }
}
