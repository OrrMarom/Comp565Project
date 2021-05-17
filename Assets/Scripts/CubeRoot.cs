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

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RadiusDestroy(GameObject g, Vector3 force_vector, int iterations)
    {
        Debug.Log("Destroying with " + iterations + " iterations");
        Transform t = g.transform;
        double range = 2.5;
        float force_intensity = 10f;

        // Do own first
        g.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        // Now do all gameobjects in radius
        foreach (GameObject gObj in cubeList)
        {
            float distanceSqr = (t.position - gObj.transform.position).sqrMagnitude;
            if (distanceSqr < range)
            {
                // Commenting out above cube code because there are problems with excess cubes not being deleted
                // Will fix in future

                //var ray = new Ray(gObj.transform.position, Vector3.up);
                //var above = Physics.RaycastAll(ray);
                //int i = 0;
                //foreach (RaycastHit cube in above){
                //    if (i > 3) break;
                //    cube.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //    // make sure cubes 
                //    gObj.AddComponent<CubeDestruction>();
                //    gObj.GetComponent<CubeDestruction>().explode(force_vector, force_intensity);
                //    i++;
                //}
                gObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gObj.AddComponent<CubeDestruction>();
                gObj.GetComponent<CubeDestruction>().explode(force_vector, force_intensity);
            }
        }
    }
}
