using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 posOffset;
    public Vector3 rotOffset;
    public bool followRotation;
    void Update()
    {
        transform.position = followTarget.position + posOffset;
        if (followRotation)
        {
            transform.rotation = followTarget.rotation * Quaternion.Euler(rotOffset);
        }
    }
}
