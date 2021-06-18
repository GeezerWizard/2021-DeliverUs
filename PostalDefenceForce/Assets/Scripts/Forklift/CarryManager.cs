using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour
{
    public GameObject packagePivot;
    private GameObject package;
    private ConfigurableJoint packageJoint;

    private void Start() {
        packageJoint = packagePivot.GetComponent<ConfigurableJoint>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Carryable" && package == null)
        {
            package = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Carryable")
        {
            package = null;
        }
    }

    private void AttachToPivot() {
        GameObject pivot = Instantiate(packagePivot, this.transform.position, Quaternion.identity, this.transform.parent);
        packageJoint.connectedBody = package.GetComponent<Rigidbody>();
    }

}
