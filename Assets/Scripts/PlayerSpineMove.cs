using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpineMove : MonoBehaviour
{
/*
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    float cameraPitch = 0.0f;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] Transform playerCamera = null;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    public float speed;
*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpineMove();
    }

    void UpdateSpineMove()
    {
        /*       Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

               //Debug.Log("target mouse delta: x=" + targetMouseDelta.x + " y=" + targetMouseDelta.y);

               Debug.Log("Main Camera x angale: " + Camera.main.transform.rotation.eulerAngles.x);
               float mainCameraYRotation = Camera.main.transform.eulerAngles.y;*/
        // Debug.Log("Object x angale: " + gameObject.transform.eulerAngles.x);
        //gameObject.transform.Rotate(gameObject.transform.eulerAngles.x, mainCameraYRotation, gameObject.transform.eulerAngles.z);

        //gameObject.transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.x, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z);

/*        var x = UnityEditor.TransformUtils.GetInspectorRotation(Camera.main.transform).x;
        var y = UnityEditor.TransformUtils.GetInspectorRotation(Camera.main.transform).y;
        var z = UnityEditor.TransformUtils.GetInspectorRotation(Camera.main.transform).z;
        Debug.Log("x: " + x);
        Debug.Log("y: " + y);
        Debug.Log("z: " + z);

        Vector3 anglesToRotate = new Vector3(
            x * Time.deltaTime,
            gameObject.transform.eulerAngles.y,
            gameObject.transform.eulerAngles.z
        );

        gameObject.transform.Rotate(anglesToRotate);*/

        /*gameObject.transform.eulerAngles = new Vector3(
            x,
            gameObject.transform.eulerAngles.y,
            gameObject.transform.eulerAngles.z
        );*/

        /*        Vector3 upAxis = Vector3.up;
                transform.rotation = Quaternion.LookRotation(Vector3.Cross(upAxis, Vector3.Cross(upAxis, Camera.main.transform.forward)), upAxis);
        */
        /*        Vector3 newPos = gameObject.transform.position;

                newPos += (playerCamera.transform.right * (float)mouseSensitivity);

                gameObject.transform.position = newPos;*/
        /*
                Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

                cameraPitch -= currentMouseDelta.y * mouseSensitivity;
                cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

                playerCamera.localEulerAngles = Vector3.right * cameraPitch;
                gameObject.transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);*/
    }
}
