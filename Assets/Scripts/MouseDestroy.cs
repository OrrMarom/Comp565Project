using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDestroy : MonoBehaviour
{

    // Hold reference to MazeLevel to bake navmesh
    static MazeLevel mazeLevel;

    // Update is called once per frame
    void Update()
    {
        // Use raycast to update preview object
        RaycastHit hitInfo = new RaycastHit();

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            // Place object
            if (Input.GetMouseButtonUp(0))
            {
                // Get vector from player to point
                Vector3 v1 = Camera.main.transform.position;
                Vector3 v2 = hitInfo.point;

                // Pointing away from player towards object
                Vector3 force = v2 - v1;

                Debug.Log(hitInfo.collider.name);
                Debug.Log(hitInfo.collider.tag);

                // Check to ensure we are hitting a wall to destroy
                if (hitInfo.collider.tag == "DestructableCube")
                {
                    hitInfo.collider.gameObject.transform.parent.GetComponentInParent<CubeRoot>().RadiusDestroy(hitInfo.collider.gameObject, force, 1);

                    // Update navmesh
                    if (mazeLevel == null)
                    {
                        mazeLevel = GameObject.Find("LevelController").GetComponent<MazeLevel>();
                    }
                    // Update navmesh to reflect destroyed environment 
                    StartCoroutine(UpdateNavMesh());
                }
                // Check to see if we are hitting an enemy
                else if (hitInfo.collider.tag == "Enemy")
                {
                    hitInfo.collider.GetComponent<Enemy>().DestroyEnemy();
                }
            }
        }
    }

    IEnumerator UpdateNavMesh()
    {
        yield return new WaitForSeconds(2);
        mazeLevel.UpdateNavMesh();
    }
}
