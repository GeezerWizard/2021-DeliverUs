using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnCollision : MonoBehaviour
{
    public int hitForce;
    //public GameObject colliderObject;
    //Collider2D hitCollider;
    /*
    private void Start()
    {
        hitCollider = colliderObject.GetComponent<Collider2D>();
    }*/
    //Collider2D hitCollider;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        if (other.CompareTag("Enemy"))
        {
            other.attachedRigidbody.AddForce(hitForce * (other.transform.position - transform.position).normalized, ForceMode2D.Impulse);
        }
    }
}
