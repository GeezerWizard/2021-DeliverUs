using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftCarryControls : MonoBehaviour
{
    public Transform packagePivotPrefab;
    private  ConfigurableJoint packageJoint;
    private Rigidbody rb;
    private GameObject package;
    private Transform curPackagePivot;
    private bool carrying;
    public float maxHeight;
    private Vector3 maxPos;
    public float minHeight;
    private Vector3 minPos;
    public float speed;
    private bool move;
    private Vector3 targetPos;

    private void Start() {
        carrying = false;
        move = true;
        maxPos = new Vector3(0, maxHeight, 0);
        minPos = new Vector3(0, minHeight, 0);
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update() {
        if (curPackagePivot == null) { //when curPackagePivot gets destroyed externally
            carrying = false;
        }
        if (Input.GetKey(PlayerControls.forkUp) && this.transform.position.y < maxHeight) {
            move = true;
            targetPos = Vector3.up * speed;
            if (package != null && !carrying && this.transform.position.y > minHeight + 0.1f) {
                AttachPackage();
                carrying = true;
            }
        }
        else if (Input.GetKey(PlayerControls.forkDown) && this.transform.position.y > minHeight) {
            move = true;
            targetPos = Vector3.down * speed;
            if (carrying && this.transform.position.y <minHeight + 0.1f) {
                DetachPackage();
                carrying = false;
            }
        }
        else {
            move = false;
        }
    }

    private void FixedUpdate() {
        if (curPackagePivot != null) {
            Vector3 offset = new Vector3(0, 0.2f, 0); // maybe make into public variable
            curPackagePivot.transform.position = this.transform.position + offset;
            print("force position stay");
        }
        if (move) {
            rb.MovePosition(this.transform.position + targetPos * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Carryable" && package == null) {
            package = other.gameObject;
            print(package);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Carryable" && package != null) {
            package = null;
        }
    }

    private void AttachPackage() {
        curPackagePivot = Instantiate(packagePivotPrefab, this.transform.position, Quaternion.identity, this.transform.parent);
        packageJoint = curPackagePivot.GetComponent<ConfigurableJoint>();
        packageJoint.connectedBody = package.GetComponent<Rigidbody>();
        print("attach");
    }

    private void DetachPackage() {
        Destroy(curPackagePivot.gameObject);
        print("detach");
    }
}
