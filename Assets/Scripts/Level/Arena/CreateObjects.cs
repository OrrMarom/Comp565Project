using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    // Constants
    public GameObject prefabCube;

    public float width = 0.0f;
    public float height = 0.0f;
    public float depth = 0.0f;
    public float blockWidth = 0.2f;

    //------------------------//

    [ContextMenu("CreateBlock")]
    void createBlock() {
        Debug.Log("Creating block...");
        // gameObject.name + block
        // this.transform.position or gameObject.name
        Vector3 position = new Vector3(0, 0, 0);

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        int cubeCount = 5;

        for (int i = 0; i < cubeCount; i++) {
            for (int j = 0; j < cubeCount; j++) {
                for (int k = 0; k < cubeCount; k++) {
                    GameObject cube = Instantiate(prefabCube, new Vector3(x, y, z), Quaternion.identity); // clone cube 
                    cube.GetComponent<Renderer>().material = prefabCube.GetComponent<Renderer>().sharedMaterial;
                    cube.transform.SetParent(gameObject.transform);
                    z += blockWidth;
                }
                z = 0.0f;
                y += blockWidth;
            }
            y = 0.0f;
            x += blockWidth;
        }
    }

    [ContextMenu("CreateWall")]
    void createWall() {
        Debug.Log("Creating wall...");
        if (width == 0.0f) {
            width = 10.0f;
        }
        if (height == 0.0f) {
            height = 10.0f;
        }
        if (blockWidth == 0.0f) {
            blockWidth = 0.2f;
        }
        float z = 0.0f;

        for (float x = 0.0f; x < width; x += blockWidth) {
            for (float y = 0.0f; y < height; y += blockWidth) {
                GameObject cube = Instantiate(prefabCube, new Vector3(x, y, z), Quaternion.identity);
                cube.GetComponent<Renderer>().material = prefabCube.GetComponent<Renderer>().sharedMaterial;
                cube.transform.SetParent(gameObject.transform);
            }
        }
    }

    public float stairHeight = 8.0f;
    public float stairWidth = 5.0f;

    [ContextMenu("CreateStairs")]
    void createStairs() {
        Debug.Log("Creating stairs...");
        // blockWidth = 5.0f;

    }

    [ContextMenu("CreatePillar")]
    void createPillar() {
        Debug.Log("Creating pillar...");
    }

    [ContextMenu("CreatePlatform")]
    void createPlatform() {
        Debug.Log("Creating platform...");
    }

    [ContextMenu("CreateFloorTile")]
    void createFloorTile() {

        if (prefabCube == null) {
            prefabCube = gameObject;
            Debug.Log("No prefab cube assigned.");
        }
        

        float x = 0.0f;
        float y = transform.position.y;
        float z = 0.0f;
        int cubeCount = 5;

        for (int i = 0; i < cubeCount; i++) {
            for (int j = 0; j < cubeCount; j++) {
                GameObject cube = Instantiate(prefabCube, new Vector3(x, y, z), Quaternion.identity); // clone cube 
                cube.GetComponent<Renderer>().material = prefabCube.GetComponent<Renderer>().sharedMaterial;
                cube.transform.SetParent(gameObject.transform);
                z += blockWidth;
            }
            z = 0.0f;
            x += blockWidth;
        }
    }
}
