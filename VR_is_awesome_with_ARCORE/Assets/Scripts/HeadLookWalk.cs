using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookWalk : MonoBehaviour
{

    public float velocity = 0.7f;
    public Transform arCamera;
    private CharacterController controller;
    public bool isWalking = false;
    private Clicker clicker = new Clicker();

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 moveDirection = arCamera.transform.forward;
        moveDirection *= velocity * Time.deltaTime;
        moveDirection.y = 0.0f;
        controller.Move(moveDirection);
        */
        if(clicker.clicked())
        {
            isWalking = !isWalking;
        }
        if(isWalking)
        {
            controller.SimpleMove(arCamera.forward * velocity);
        }
        
    }
}
