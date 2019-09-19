using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorPosioner : MonoBehaviour
{
    private float defaultPosZ;
    public Transform arCamera;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(arCamera.position, arCamera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= defaultPosZ)
            {
                transform.localPosition = new Vector3(0, 0, hit.distance);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosZ);
            }
        }
    }
}
