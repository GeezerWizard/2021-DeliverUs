using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject legsToHide;
    public Transform mainBody;
    private Vector3 originalMainBodyPosition;
    private Rigidbody rb;
    private ScoreManager sm;
    private EnemyAI ai;
    int health = 3;
    float onHitInvincibleTime = 0.25f;
    float falloverTime = 0.5f;
    float invincibleTime = 2f;
    bool isInvincible;
    bool isDead = false;
    int defaultDrag = 3;
    int dragModifier = 25;
    void Awake()
    {
        ai = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody>();
        sm = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        rb.drag = defaultDrag;
        isInvincible = false;
        originalMainBodyPosition = mainBody.localPosition;
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
            StartCoroutine(Death());
        }
        Debug.Log(health);
    }
    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(onHitInvincibleTime);

        isInvincible = false;
        yield return new WaitForSeconds(falloverTime);
        
        SetDrag(defaultDrag * dragModifier);
        isInvincible = true;
        SetBodyCrouch(true);
        yield return new WaitForSeconds(invincibleTime - falloverTime);
        
        SetDrag(defaultDrag);
        isInvincible = false;
        SetBodyCrouch(false);

        yield return null;
    }
    IEnumerator Death()
    {
        isDead = true;
        sm.AddEnemiesDefeated();
        ai.enabled = false;
        yield return new WaitForSeconds(falloverTime);
        
        SetDrag(defaultDrag);
        legsToHide.SetActive(false);
        rb.constraints = RigidbodyConstraints.None;
    }

    public void SetDrag(float amount)
    {
        rb.drag = amount;
        rb.angularDrag = amount;
    }
    public void SetBodyCrouch(bool crouch)
    {
        if (crouch)
        {
            mainBody.localPosition = originalMainBodyPosition - new Vector3(0, 0.5f, 0);
        }
        if (!crouch)
        {
            mainBody.localPosition = originalMainBodyPosition;
        }
    }
}
