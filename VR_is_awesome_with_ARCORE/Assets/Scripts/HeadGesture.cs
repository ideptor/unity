using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadGesture : MonoBehaviour
{

    public bool isFacingDown = false;
    public bool isMovingDown = false;

    private float sweepRate = 100.0f;
    private float previousCameraAngle;

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
        isMovingDown = DetectMovingDown();
    }

    private bool DetectFacingDown()
    {
        return (CameraAngleFromGround() < 70.0f);
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

    private bool DetectMovingDown()
    {
        float angle = CameraAngleFromGround();
        float deltaAngle = previousCameraAngle - angle;
        float rate = deltaAngle / Time.deltaTime;
        previousCameraAngle = angle;

        return (rate >= sweepRate);
    }
}
