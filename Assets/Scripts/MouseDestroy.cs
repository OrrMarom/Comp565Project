using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

                hitInfo.collider.gameObject.GetComponentInParent<CubeRoot>().RadiusDestroy(hitInfo.collider.gameObject, force, 1);
            }
        }
    }
}
