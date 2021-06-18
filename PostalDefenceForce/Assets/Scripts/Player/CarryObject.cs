using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public string objectTag;
    [SerializeField]
    private GameObject highlightedObject;
    private GameObject carriedObject;
    [SerializeField]
    private List<GameObject> detectedObjects;
    private bool objectIsHighlighted;
    private bool carryingObject;
    public Material highlightMat;
    public Mesh highLightMesh;

    private void Start() {
        if (objectTag == null)
        {
            Debug.Log("Carryable object tag not set.");
        }
    }

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
        if (col.tag == objectTag)
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
        if (col.tag == objectTag)
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