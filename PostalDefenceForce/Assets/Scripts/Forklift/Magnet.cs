using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Rigidbody rb;
    public float magneticForceMultiplier;
    private void Update()
    {
        //print();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Carryable")
        {
            rb = col.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (rb == null)
        {
            rb = col.GetComponent<Rigidbody>();
        }
        if (col.tag == "Carryable")
        {
            Vector3 magneticForce = this.transform.position - col.transform.position;
            rb.AddForce(magneticForce * magneticForceMultiplier, ForceMode.VelocityChange);
            //rb.isKinematic = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        //rb.isKinematic = false;
    }
}
