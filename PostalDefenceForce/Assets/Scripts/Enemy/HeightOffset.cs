using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightOffset : MonoBehaviour
{
    public Transform objectToOffset;
    public Transform targetObject;
    public float length;
    public float defaultHeight;
    private float minHeight = 0.1f;
    private Quaternion startRotation;
    void Start()
    {
        startRotation = objectToOffset.rotation;
    }
    void Update()
    {
        float dist = Vector3.Distance(transform.position, targetObject.position);
        if (dist < length && dist > minHeight)
        {
            SetYOffset(dist+defaultHeight);
        }
        /*if (dist >= length)
        {
            SetYOffset(-length);
        }
        if (dist <= minHeight)
        {
            SetYOffset(minHeight);
        }*/
        //Use target objects y as rotation for object to offset for control
        //Vector3 tempRot = objectToOffset.rotation.eulerAngles;
        //tempRot.z = -1 * targetObject.transform.rotation.eulerAngles.y;
        //print(Quaternion.Euler(tempRot));
        //objectToOffset.rotation = Quaternion.Euler(tempRot);
        //objectToOffset.rotation = startRotation * Quaternion.Inverse(transform.parent.rotation);
        Vector3 relativePos = targetObject.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        objectToOffset.localRotation = Quaternion.AngleAxis(-targetObject.transform.rotation.eulerAngles.y, Vector3.forward);

    }
    void SetYOffset(float offset)
    {
        objectToOffset.localPosition = new Vector3(objectToOffset.localPosition.x, objectToOffset.localPosition.y, offset);
    }
}
