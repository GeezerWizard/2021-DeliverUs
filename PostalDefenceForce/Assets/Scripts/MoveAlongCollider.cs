using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongCollider : MonoBehaviour
{
    public Collider conveyor;
    public Vector3 moveDirection;
    public int movementForce;

    private void OnTriggerStay(Collider col)
    {
        //col.attachedRigidbody.AddForce(moveDirection * movementForce, ForceMode.VelocityChange);
        if (col.tag == "Carryable")
        {
            col.transform.position += moveDirection/50;
        }
    }
}
