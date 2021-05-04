using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    float dpsYAxis = 30.0f; // dps = degrees per second; rotate around Y-Axis
    float dpsXAxis = 20.0f;
    float amplitude = 0.5f;
    float frequency = 1.0f;
    float targetHeight;
    Vector3 startPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        targetHeight = Random.Range(14.0f, 20.0f);
        startPos = transform.position;
        startPos.y = targetHeight;   
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;

        transform.Rotate(new Vector3(0.0f, Time.deltaTime * dpsYAxis, 0.0f), Space.World);
    }
}
