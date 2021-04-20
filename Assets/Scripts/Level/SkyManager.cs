using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    GameObject skydome;
    GameObject clouds;
    GameObject stars;
    float offsetIncrement = 0.01f;
    float textureUVOffset = 0.0f;

    Vector3 cloudPosition;

    // Start is called before the first frame update
    void Start()
    {
        skydome = GameObject.Find("SkyDome");
        clouds = GameObject.Find("Clouds");
        stars = GameObject.Find("SkyDome/Stars");
        cloudPosition = clouds.transform.position;
        cloudPosition = new Vector3(34.0f, 24.0f, 24.0f);
    }

    void Update()
    {
        changeCloudPosition(0.0f * Time.deltaTime, 1.0f * Time.deltaTime);
    }


    void changeTimeOfDay(float offset) {
        if (offset <= 1 || offset >= 0)
        {
            skydome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }

    void changeCloudPosition(float x, float z) {
        Vector3 offset = new Vector3(x, 0, z);
        clouds.transform.position += offset;
        if (clouds.transform.position.x > 500.0f || clouds.transform.position.z > 500.0f) {
            clouds.transform.position = new Vector3(34.0f, 24.0f, -500.0f);
        }
    }

    void changeStarsPosition(Vector3 offset) {
        stars.transform.Translate(offset);
    }
}
