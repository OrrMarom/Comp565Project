using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRoot : MonoBehaviour
{
    public int x_size;
    public int y_size;
    public int z_size;

    List<GameObject> cubeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("DestructableCube"))
        {
            cubeList.Add(g);
        }
    }

    public void RadiusDestroy(GameObject g, Vector3 force_vector, int iterations)
    {
        Transform t = g.transform;
        double range = 3.5;
        float force_intensity = 10f;

        // Do own first
        g.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        // Now do all gameobjects in radius
        foreach (GameObject gObj in cubeList)
        {
            float distanceSqr = (t.position - gObj.transform.position).sqrMagnitude;
            if (distanceSqr < range)
            {
                // Ensure cube still has proper tag and can be destroyed
                if (gObj.tag == "DestructableCube")
                {
                    gObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    gObj.AddComponent<CubeDestruction>();
                    gObj.GetComponent<CubeDestruction>().explode(force_vector, force_intensity);
                }
            }
        }
    }
}
