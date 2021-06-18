using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThisTransform : MonoBehaviour
{
    public Transform[] followingObjects;
    public Vector3 offset;

    private void Update() {
        foreach (Transform obj in followingObjects) {
            obj.localPosition = new Vector3(obj.localPosition.x, this.transform.localPosition.y, obj.localPosition.z) + offset;
        }    
    }
}
