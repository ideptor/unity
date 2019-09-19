using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippinDashBoard : MonoBehaviour
{
    private HeadGesture gesture;
    private GameObject dashboard;
    private bool isOpen = true;
    private Vector3 startRotation;

    // Start is called before the first frame update
    void Start()
    {
        gesture = GetComponent<HeadGesture>();
        dashboard = GameObject.Find("Dashboard");
        startRotation = dashboard.transform.eulerAngles;
        CloseDashboard();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(gesture.isFacingDown)
        {
            OpenDashboard();
        } else
        {
            CloseDashboard();
        }
    }

    private void OpenDashboard()
    {
        if (!isOpen)
        {
            dashboard.transform.eulerAngles = startRotation;
            isOpen = true;
        }
    }

    private void CloseDashboard()
    {
        if (isOpen)
        {
            dashboard.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            isOpen = false;
        }
    }


}
