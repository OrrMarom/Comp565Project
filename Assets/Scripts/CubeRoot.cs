using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRoot : MonoBehaviour
{
    GameObject[,] cubeArr = new GameObject[16, 8];

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                cubeArr[x, y] = gameObject.transform.GetChild(count++).gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyNearby(GameObject g, int iterations)
    {
        Debug.Log("Destroying with " + iterations + " iterations");
        int x_base = 0;
        int y_base = 0;
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (cubeArr[x,y] == g)
                {
                    x_base = x;
                    y_base = y;
                }
            }
        }
        // Destroy cube
        Destroy(g);

        List<int> xs_to_destroy = new List<int>();
        List<int> ys_to_destroy = new List<int>();

        xs_to_destroy.Add(x_base);
        xs_to_destroy.Add(y_base);

        // Destroy nearby cubes
        for (int i = 0; i < iterations; i++)
        {
            List<int> new_xs_to_destroy = new List<int>();
            List<int> new_ys_to_destroy = new List<int>();
            for (int j = 0; j < xs_to_destroy.Count; j++)
            {
                Destroy(cubeArr[xs_to_destroy[j], ys_to_destroy[j]]);

                if (xs_to_destroy[j] - 1 >= 0)
                {
                    new_xs_to_destroy.Add(xs_to_destroy[j] - 1);
                    new_ys_to_destroy.Add(ys_to_destroy[j]);
                }                
                if (ys_to_destroy[j] - 1 >= 0)
                {
                    new_xs_to_destroy.Add(xs_to_destroy[j]);
                    new_ys_to_destroy.Add(ys_to_destroy[j] - 1);
                }                
                if (xs_to_destroy[j] + 1 <= 15)
                {
                    new_xs_to_destroy.Add(xs_to_destroy[j] + 1);
                    new_ys_to_destroy.Add(ys_to_destroy[j]);
                }                
                if (ys_to_destroy[j] + 1 <= 7)
                {
                    new_xs_to_destroy.Add(xs_to_destroy[j]);
                    new_ys_to_destroy.Add(ys_to_destroy[j] + 1);
                }
            }

            xs_to_destroy = new_xs_to_destroy;
            ys_to_destroy = new_ys_to_destroy;

        }
    }
}
