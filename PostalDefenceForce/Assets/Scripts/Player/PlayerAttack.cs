using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //References
    private Rigidbody rb;
    public Transform attackObject;
    Transform parentTransform;
    Vector3 parentRotation;
    //Variables
    public float fullSwingAngle = 120;
    float initialAngle;
    float endAngle;
    public float attackDuration = 0.65f;
    float startTime;
    Collider hitCollider;
    KeyCode attackKey = KeyCode.Space;

    private void Start()
    {
        hitCollider = attackObject.GetComponentInChildren<Collider>();
        hitCollider.enabled = false;
        rb = transform.GetComponent<Rigidbody>();
        parentTransform = attackObject.parent;
    }
    private void Update()
    {
        //makes object face direction of movement while not attacking
        if (hitCollider.enabled == false && rb.velocity != Vector3.zero) //only changes angle when not attacking
        {
            //Vector2 direction = rb.velocity.normalized; //gets the direction
            //facingAngle = Vector2.SignedAngle(Vector2.up, direction); //transforms direction into an angle
            //Face the local facing angle directed by the PlayerMovement script
            attackObject.localRotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(attackKey) && !hitCollider.enabled)
        {
            parentRotation = parentTransform.rotation.eulerAngles;
            Attack(parentRotation.y);
        }

        if (hitCollider.enabled == true)
        {
            float t = Time.time - startTime;
            if(t < attackDuration)
            {
                float y = Mathf.SmoothStep(initialAngle, endAngle, (t / attackDuration));
                attackObject.rotation = Quaternion.Euler(new Vector3(0, y, 0));
            }
            else
            {
                EndAttack();
            }
        }
    }
    private void Attack(float facingAngle)
    {
        hitCollider.enabled = true;
        initialAngle = facingAngle + (fullSwingAngle/2);
        endAngle = facingAngle - (fullSwingAngle/2);
        GetStartTime();
    }
    private void EndAttack()
    {
        hitCollider.enabled = false;
        attackObject.localRotation = Quaternion.identity;
    }
    private void GetStartTime()
    {
        startTime = Time.time;
    }
}
