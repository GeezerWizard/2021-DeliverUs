using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 posOffset;
    void FixedUpdate()
    {
        transform.position = objectToFollow.position + posOffset;
    }
}
