using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cam;

    void Start()
    {
        cam.Priority = -50;
        /* 
         * You can access with GetComponent like below but it's not smart.
         * this.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = -50;
         * Attaching GameObject or Component with public statement: serialized field
         * make your code simple and fast.
         */
    }

    void Update()
    {
        // Abbreviated style: Only handle 1 line.
        if (Input.GetKeyDown(KeyCode.Return)) cam.Priority *= -1;
    }
}
