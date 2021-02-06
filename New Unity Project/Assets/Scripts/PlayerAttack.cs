using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //References
    Rigidbody2D rb;
    public Transform attackObject;
    Transform parentTransform;
    Vector3 parentRotation;
    //Variables
    float fullSwingAngle = 120;
    float initialAngle;
    float endAngle;
    public float attackDuration = 0.65f;
    float startTime;
    Collider2D hitCollider;

    private void Start()
    {
        hitCollider = attackObject.GetComponentInChildren<CircleCollider2D>();
        hitCollider.enabled = false;
        rb = transform.GetComponent<Rigidbody2D>();
        parentTransform = attackObject.parent;
    }
    private void Update()
    {
        //makes object face direction of movement while not attacking
        if (hitCollider.enabled == false && rb.velocity != Vector2.zero) //only changes angle when not attacking
        {
            //Vector2 direction = rb.velocity.normalized; //gets the direction
            //facingAngle = Vector2.SignedAngle(Vector2.up, direction); //transforms direction into an angle
            //Face the local facing angle directed by the PlayerMovement script
            attackObject.localRotation = Quaternion.identity; 
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && hitCollider.enabled == false)
        {
            parentRotation = parentTransform.rotation.eulerAngles;
            Attack(parentRotation.z);
        }

        if (hitCollider.enabled == true)
        {
            float t = Time.time - startTime;
            if(t < attackDuration)
            {
                float z = Mathf.SmoothStep(initialAngle, endAngle, (t / attackDuration));
                attackObject.rotation = Quaternion.Euler(new Vector3(0, 0, z));
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
