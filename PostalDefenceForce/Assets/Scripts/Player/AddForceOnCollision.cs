using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnCollision : MonoBehaviour
{
    public int hitForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.attachedRigidbody.AddForce(hitForce * (other.transform.position - transform.position).normalized, ForceMode.Impulse);
        }
    }
}
