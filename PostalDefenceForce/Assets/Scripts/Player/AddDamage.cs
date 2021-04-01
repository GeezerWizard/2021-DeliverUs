using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamage : MonoBehaviour
{
    EnemyHealth health;
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            health = other.gameObject.GetComponent<EnemyHealth>();
            health.ChangeHealth(-damage);
        }
    }
}
