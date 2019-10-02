using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGPSCompassController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var heading = 180 + Input.compass.magneticHeading;
        var rotation = Quaternion.AngleAxis(heading, Vector3.up);
        //transform.rotation = rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedTime * .001f);
    }
}
