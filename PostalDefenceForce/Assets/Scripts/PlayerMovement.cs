using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Values
    public float walkSpeed;
    public float runSpeed;
    float runSpeedMultiplier;
    Vector2 movement;
    float xMov;
    float yMov;
    float facingAngle;
    float lastFacingAngle;

    //References
    Rigidbody2D rb;
    public Transform objectToRotate;

    //Directional Movement Key Remapping
    KeyCode upKey= KeyCode.W;
    KeyCode downKey = KeyCode.S;
    KeyCode rightKey = KeyCode.D;
    KeyCode leftKey = KeyCode.A;
    KeyCode runKey = KeyCode.LeftShift;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        if(Input.GetKey(runKey))
        {
            runSpeedMultiplier = runSpeed;
        }
        else { runSpeedMultiplier = 1; }

        if(Input.GetKey(upKey))
        {
            yMov = 1;
        }
        else if (Input.GetKey(downKey))
        {
            yMov = -1;
        }
        //If neither, reset vertical movement to zero
        else { yMov = 0; }

        if (Input.GetKey(rightKey))
        {
            xMov = 1;
        }
        else if (Input.GetKey(leftKey))
        {
            xMov = -1;
        }
        //If neither, reset horizontal movement to zero
        else { xMov = 0; }
        //Sets the direction for movement
        movement = new Vector2(xMov, yMov);
        //Sets the facing angle
        if(movement != Vector2.zero)
        {
            facingAngle = Vector2.SignedAngle(Vector2.up, movement);
            //Apply facing angle to object
            objectToRotate.rotation = Quaternion.Euler(0, 0, facingAngle);
        }

    }
    private void FixedUpdate()
    {
        //Apply velocity to character in movement direction
        if(movement != Vector2.zero)
        {
            //rb.velocity = movement * walkSpeed * runSpeedMultiplier;
            rb.AddForce(movement * walkSpeed * runSpeedMultiplier * 10);
        }
    }
}
