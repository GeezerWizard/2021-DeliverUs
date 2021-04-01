using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOffset : MonoBehaviour
{
    public Vector3 offset;
    void Start()
    {
        //transform.rotation = transform.rotation* Quaternion.Euler(offset);
    }
}
