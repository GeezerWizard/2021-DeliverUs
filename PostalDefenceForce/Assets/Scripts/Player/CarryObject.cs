using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    [SerializeField]
    private GameObject highlightedObject;
    private GameObject carriedObject;
    [SerializeField]
    private List<GameObject> detectedObjects;
    private bool objectIsHighlighted;
    private bool carryingObject;
    public Material highlightMat;
    public Mesh highLightMesh;

    private void Update()
    {
        if (objectIsHighlighted && !carryingObject)
        {
            Graphics.DrawMesh(highLightMesh, highlightedObject.transform.position, highlightedObject.transform.rotation, highlightMat, 0);
        }
        if (carryingObject)
        {
            highlightedObject.transform.position = this.transform.position;
            highlightedObject.transform.rotation = this.transform.rotation;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Carryable")
        {
            detectedObjects.Add(col.gameObject);
            if (!objectIsHighlighted)
            {
                highlightedObject = col.gameObject;
                objectIsHighlighted = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Carryable")
        {
            detectedObjects.Remove(col.gameObject);
            if (col.gameObject == highlightedObject)
            {
                highlightedObject = FindNextCarryableObject();
            }
        }
    }

    private GameObject FindNextCarryableObject()
    {
        float oldDistance = Mathf.Infinity;
        GameObject closestObject = null;
        if (detectedObjects.Count > 0)
        {
            foreach(GameObject a in detectedObjects)
            {
                float dist = Vector3.Distance(a.transform.position, this.transform.position);
                if (dist < oldDistance)
                {
                    oldDistance = dist;
                    closestObject = a;
                }
            }
        }
        else 
        {
            closestObject = null;
            objectIsHighlighted = false;
        }

        return closestObject;
    }
    public void Carry()
    {
        carryingObject = true;
    }
    public void Drop()
    {
        carryingObject = false;
    }
}