using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 posOffset;
    public bool followCamera;
    void FixedUpdate()
    {
        if (followCamera)
        {
            transform.position = objectToFollow.position + posOffset;
            transform.LookAt(objectToFollow.position);
        }

    }
}
