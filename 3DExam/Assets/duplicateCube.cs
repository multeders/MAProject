using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicateCube : MonoBehaviour
{
    public Camera cam;
    //public Transform CubeTransform;

    Transform t_SelectedObject;
    Transform t_AttachToObject;
    float f_CubeSize = 1f;

    // Update is called once per frame
    void Update()
    {
        
        /* If we press right mouse button  */
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // Debug.Log(Input.mousePosition);
            // Debug.Log(cam.ScreenPointToRay(Input.mousePosition));
            /* Draw ray from mouse position to check if we hit anything with certain layer */
            //Debug.Log(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit));
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Destroy(hit.transform.gameObject);
                //Debug.Log(hit.point);
                /* If we hit the same object then we de-select it */

                /*if (t_SelectedObject != null && t_SelectedObject == hit.transform)
                    t_SelectedObject = null;
                else
                    t_SelectedObject = hit.transform;
                    */
            }
        }

        /* If we press left mouse button */
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.Log("DOWN");
            /* Draw ray from mouse position to check if we hit anything with certain layer */
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                t_AttachToObject = hit.transform;
                Debug.Log(hit.point);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                t_SelectedObject = cube.transform;
                if (t_SelectedObject != null)
                {
                    /* Check if we do not hit the same object that we have selected */
                    if (t_SelectedObject != hit.transform)
                    {
                        /* Assign position with offset so the cube center won't be at click point
                         * Keep in mind that if you change your cube size you should change f_CubeSize as well */
                        //t_SelectedObject.position = hit.point + hit.normal.normalized * f_CubeSize;

                        /* If you need to Rotate it accordingly to object that you attach */
                        t_SelectedObject.rotation = hit.transform.rotation;

                        /* Function if you want attach cube to center of hitted object side */
                        t_SelectedObject.position = FindSideCenter(hit.point);

                    }
                }
            }
        }

    }

    /* Function to find right side center and return it position to attach
     * If you don't need to attach it to center, then just remove this function */
    Vector3 FindSideCenter(Vector3 hitPosition)
    {
        
        Vector3[] sides = { t_AttachToObject.right, -t_AttachToObject.right, t_AttachToObject.forward, -t_AttachToObject.forward, t_AttachToObject.up, -t_AttachToObject.up };

        float minDistance = Vector3.Distance(t_AttachToObject.position + sides[0] * f_CubeSize, hitPosition);
        int sideIndex = 0;

        for (int i = 1; i < 6; i++)
        {
            float curDistance = Vector3.Distance(t_AttachToObject.position + sides[i] * f_CubeSize, hitPosition);

            if (curDistance < minDistance)
            {
                minDistance = curDistance;
                sideIndex = i;
            }
        }

        return t_AttachToObject.position + sides[sideIndex] * f_CubeSize;
    }
}
