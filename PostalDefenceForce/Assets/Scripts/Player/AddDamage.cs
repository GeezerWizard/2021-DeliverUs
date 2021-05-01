using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamage : MonoBehaviour
{
    // Add damage variables
    EnemyHealth health;
    private int damage;
    public int[] damagePerStage;

    // Add force variables
    public int hitForce;
    public Transform hitAwayFrom;

    public void SetDamage(int stage)
    {
        damage = damagePerStage[stage];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health = other.gameObject.GetComponent<EnemyHealth>();
            health.ChangeHealth(-damage);
            // Apply force
            other.attachedRigidbody.AddForce(hitForce * (other.transform.position - hitAwayFrom.position).normalized, ForceMode.Impulse);
        }
    }
}
