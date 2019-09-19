using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    public Transform arCamera;
    public Transform infoBubble;

    private Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        if (infoBubble != null)
        {
            infoText = infoBubble.Find("Text").GetComponent<Text>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(arCamera.position, arCamera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(arCamera.position, arCamera.rotation * Vector3.forward * 100.0f);

        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                if(infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") + ", Z:" +
                        hit.point.y.ToString("F2");
                    infoBubble.LookAt(arCamera.position);
                    infoBubble.Rotate(0.0f, 180.0f, 0.0f);
                }
                //Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }

        }
    }
}
