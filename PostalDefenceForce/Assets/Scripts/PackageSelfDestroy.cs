using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSelfDestroy : MonoBehaviour
{
    private ConfigurableJoint joint;
    void Start() {
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update() {
        if (joint == null) {
            Destroy(this.gameObject);
        }
    }
}
