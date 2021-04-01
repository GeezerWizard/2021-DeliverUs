using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyAI ai;
    Rigidbody rb;
    ScoreManager sm;
    int health = 3;
    float instantInvincibility = 0.25f;
    float falloverTime = 0.5f;
    float invincibleTime = 2f;
    bool isInvincible;
    bool isDead = false;
    int defaultDrag = 8;
    int dragModifier = 4;
    void Awake()
    {
        ai = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody>();
        sm = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        rb.drag = defaultDrag;
        isInvincible = false;
    }
    public void ChangeHealth(int amount)
    {
        if(health > 0 && !isInvincible)
        {
            health += amount;
            if(health > 0)
            {
                StartCoroutine(Invincible());
            }
        }

        if(health <= 0 && !isDead)
        {
            StartCoroutine(Death(true));
        }
        //Debug.Log(health);
    }
    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(instantInvincibility);
        isInvincible = false;
        yield return new WaitForSeconds(falloverTime);
        rb.drag = rb.drag * dragModifier;
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime - falloverTime);
        rb.drag = defaultDrag;
        isInvincible = false;
        yield return null;
    }
    IEnumerator Death(bool status)
    {
        isDead = status;
        sm.AddEnemiesDefeated();
        ai.enabled = false;
        yield return new WaitForSeconds(falloverTime);
        rb.drag = defaultDrag * dragModifier;
    }
}
