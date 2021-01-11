using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    public float speed;
    //public Camera cam;

    private float minFov = 1f;
    private float maxFov = 900f;
    private float sensitivity = 10f;

    // Update is called once per frame
    void Update()
    {
        //.transform.position = new Vector3(0, 20, 0);
        if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
            //cam.transform.position = (cam.transform.position - gameObject.transform.position).normalized * Input.GetAxis("Mouse ScrollWheel");
            //cam.transform.position = new Vector3(0, 0, cam.transform.position.z + Input.GetAxis("Mouse ScrollWheel"));
        }
        //cam.transform.position = new Vector3(0, 0, cam.transform.position.z + Input.GetAxis("Mouse ScrollWheel"));
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKey("up"))
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("down"))
        {
            transform.Rotate(-1 * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -1 * speed * Time.deltaTime, 0);
        }
        
    }
}
