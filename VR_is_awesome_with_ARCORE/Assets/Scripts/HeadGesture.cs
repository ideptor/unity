using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadGesture : MonoBehaviour
{

    public bool isFacingDown = false;
    public Transform arcamera;

    private Text angleDisplay;


    // Start is called before the first frame update
    void Start()
    {
        angleDisplay = GameObject.Find("AngleDisplay").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        isFacingDown = DetectFacingDown();
    }

    private bool DetectFacingDown()
    {
        return (CameraAngleFromGround() < 40.0f);
    }

    private float CameraAngleFromGround()
    {
        float angle = Vector3.Angle(Vector3.down, arcamera.rotation * Vector3.forward);
        if(angleDisplay != null)
        {
            angleDisplay.text = "HeadAngle: " + angle.ToString("F2");
        }
        return angle;
    }
}
