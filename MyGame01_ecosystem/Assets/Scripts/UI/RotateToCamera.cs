using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    // LateUpdate is called after Update()
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
