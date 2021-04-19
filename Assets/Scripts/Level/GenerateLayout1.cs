using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLayout1 : MonoBehaviour
{
    public GameObject panel;
    public int width; // unit size
    public int depth; // unit size
    void Start()
    {
        if (width == 0 || depth == 0) {
            width = 30;
            depth = 30;
        }

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < depth; z++) {
                GameObject obj = Instantiate(panel, new Vector3(x * panel.transform.localScale.x, 0, z * panel.transform.localScale.z), Quaternion.identity);
                //obj.AddComponent<>(); // Assets/Scripts/Level/
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}
