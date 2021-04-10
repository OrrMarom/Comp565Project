using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestruction : MonoBehaviour
{
    static int subcube_rows = 2;
    static float cube_size = 1.0f / subcube_rows;
    static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode(Vector3 force_vector, float force_intensity)
    {
        // Parent cube should be hidden and without collision
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        // Material for all subcubes
        Material subcube_mat = new Material(GetComponent<Renderer>().material);
        List<GameObject> subcubes = new List<GameObject>();

        // Create all subcubes
        for (int x = 0; x < subcube_rows; x++)
        {
            for (int y = 0; y < subcube_rows; y++)
            {
                for (int z = 0; z < subcube_rows; z++)
                {
                    GameObject g = createSubcube(x, y, z, subcube_mat);
                    g.layer = LayerMask.NameToLayer("Ignore Raycast");
                    g.name = "subcube " + count++;
                    //g.transform.parent = null;
                    g.GetComponent<Rigidbody>().AddForce(force_vector * force_intensity);
                    subcubes.Add(g);
                }
            }
        }
    }

    GameObject createSubcube(int x, int y, int z, Material subcube_mat)
    {
        GameObject subcube;
        subcube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        subcube.transform.position = transform.position + new Vector3(cube_size * x, cube_size * y, cube_size * z);
        subcube.transform.localScale = new Vector3(cube_size, cube_size, cube_size);

        subcube.AddComponent<Rigidbody>();
        subcube.GetComponent<Rigidbody>().mass = cube_size;
        subcube.GetComponent<Renderer>().material = subcube_mat;
        StartCoroutine(fadeAndDestroy(subcube));
        return subcube;
    }

    public IEnumerator fadeAndDestroy(GameObject subcube)
    {
        float time_until_fade = Random.Range(1f, 2f);
        float fade_until_destroy = 3f;
        float alpha = 1.0f;

        // Delay fade for some time
        yield return new WaitForSeconds(time_until_fade);

        // Fade cube out and destroy
        Material subcube_mat = subcube.GetComponent<Renderer>().material;
        while (alpha > 0.0f)
        {
            alpha = subcube_mat.color.a - (fade_until_destroy * Time.deltaTime);
            subcube_mat.color = new Color(subcube_mat.color.r, subcube_mat.color.g, subcube_mat.color.b, alpha);
            yield return new WaitForEndOfFrame();
        }
        Destroy(subcube);

        yield return null;
    }
}
