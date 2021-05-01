using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //References
    private AddDamage damage;
    private Rigidbody rb;
    public Transform attackObject;
    Transform parentTransform;
    Vector3 parentRotation;
    //Variables
    public float fullSwingAngle = 120;
    private int swingAngleModifier = 0;
    float initialAngle;
    float endAngle;
    public float attackDuration = 0.65f;
    float startTime;
    Collider hitCollider;
    KeyCode attackKey = KeyCode.Space;
    KeyCode altAttackKey = KeyCode.Mouse0;
    //Power up attack variables
    private float holdTimer;
    private float secondsForMediumAttack = 1f;
    private float secondsForHeavyAttack = 2f;

    private void Start()
    {
        hitCollider = attackObject.GetComponentInChildren<Collider>();
        hitCollider.enabled = false;
        rb = transform.GetComponent<Rigidbody>();
        damage = GetComponentInChildren<AddDamage>();
        parentTransform = attackObject.parent;
        parentRotation = parentTransform.rotation.eulerAngles;
    }
    private void Update()
    {
        float swingAngle = fullSwingAngle/2 + swingAngleModifier;
        //makes object face direction of movement while not attacking (for when locked)
        /*if (hitCollider.enabled == false && rb.velocity != Vector3.zero) //only changes angle when not attacking
        {
            attackObject.localRotation = Quaternion.identity;
        }*/
        if (hitCollider.enabled == false)
        {
            attackObject.localRotation = Quaternion.identity;
            swingAngleModifier = 0;
        }
        if ((Input.GetKeyDown(attackKey) | Input.GetKeyDown(altAttackKey)) && !hitCollider.enabled)
        {
            holdTimer = 0;
            //SetAttackAngle(parentRotation.y);
            //attackObject.rotation = Quaternion.Euler(0, initialAngle, 0);

        }
        if ((Input.GetKey(attackKey) | Input.GetKey(altAttackKey)) && !hitCollider.enabled)
        {
            holdTimer += Time.deltaTime;
            attackObject.localRotation = Quaternion.Euler(0, swingAngle, 0);
            if (holdTimer >= secondsForHeavyAttack)
            {
                swingAngleModifier = 25;
            }
            else if (holdTimer >= secondsForMediumAttack)
            {
                swingAngleModifier = 12;
            }
            else { swingAngleModifier = 0;}
        }
        if ((Input.GetKeyUp(attackKey) | Input.GetKeyUp(altAttackKey)) && !hitCollider.enabled)
        {
            initialAngle = swingAngle;
            endAngle = -swingAngle;
            if(holdTimer >= secondsForHeavyAttack)
            {
                damage.SetDamage(2);
            }
            else if (holdTimer >= secondsForMediumAttack)
            {
                damage.SetDamage(1);
            }
            else if (holdTimer <secondsForMediumAttack)
            {
                damage.SetDamage(0);
            }
            Attack();
        }

        if (hitCollider.enabled == true)
        {
            float t = Time.time - startTime;
            if(t < attackDuration)
            {
                float y = Mathf.SmoothStep(initialAngle, endAngle, (t / attackDuration));
                attackObject.localRotation = Quaternion.Euler(new Vector3(0, y, 0));
            }
            else
            {
                EndAttack();
            }
        }
    }
    /*
    private void SetAttackAngle(float facingAngle)
    {
        initialAngle = facingAngle + (fullSwingAngle/2);
        endAngle = initialAngle - (fullSwingAngle);
    }*/
    private void Attack()
    {
        hitCollider.enabled = true;
        GetStartTime();
    }
    private void EndAttack()
    {
        hitCollider.enabled = false;
        //May need to come back to this one when fixing lock facing to movement
        //attackObject.localRotation = Quaternion.identity;
    }
    private void GetStartTime()
    {
        startTime = Time.time;
    }
}
