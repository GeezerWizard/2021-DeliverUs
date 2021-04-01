using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
    public Transform targetPosition;
    public Vector3 worldUp;
    void Update()
    {
        //transform.LookAt(targetPosition);
        //Vector3 relativePos = targetPosition.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
    }
}
