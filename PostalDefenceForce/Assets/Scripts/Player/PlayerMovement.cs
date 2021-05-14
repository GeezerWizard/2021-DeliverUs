using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Values
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    float runSpeedMultiplier;
    Vector3 movement;
    float xMov;
    float zMov;
    float facingAngle;
    bool isUsingMouse = false;
    bool lockFacingToMovement = true;

    //References
    Rigidbody rb;
    public Transform objectToRotate;
    private CarryObject carryObject;

    //Directional Movement Key Remapping
    KeyCode upKey= KeyCode.W;
    KeyCode downKey = KeyCode.S;
    KeyCode rightKey = KeyCode.D;
    KeyCode leftKey = KeyCode.A;
    KeyCode runKey = KeyCode.LeftShift;
    KeyCode carryKey = KeyCode.Space;

    //Mouse Control Variables
    Plane plane;
    Vector3 mouseWorldPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plane = new Plane(Vector3.up, 0);
        carryObject = GetComponentInChildren<CarryObject>();
    }

    void Update()
    {
        if(Input.GetKey(runKey))
        {
            runSpeedMultiplier = runSpeed;
        }
        else { runSpeedMultiplier = 1; }

        //vertical controls
        if(Input.GetKey(upKey))
        {
            zMov = -1;
        }
        else if (Input.GetKey(downKey))
        {
            zMov = 1;
        }
        else { zMov = 0; }

        //horizontal controls
        if (Input.GetKey(rightKey))
        {
            xMov = -1;
        }
        else if (Input.GetKey(leftKey))
        {
            xMov = 1;
        }
        else { xMov = 0; }

        //Sets the direction for movement
        movement = new Vector3(xMov, 0, zMov);

        if (Input.GetKeyDown(carryKey))
        {
            carryObject.Carry();
        }
        if (Input.GetKeyUp(carryKey))
        {
            carryObject.Drop();
        }

        if(isUsingMouse)
        {
            float distance = 0f;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                mouseWorldPosition = ray.GetPoint(distance);
            }
            Vector3 facingDirection = mouseWorldPosition - objectToRotate.position;
            facingAngle = Vector3.SignedAngle(Vector3.forward, facingDirection, Vector3.up);
            objectToRotate.rotation = Quaternion.Euler(0, facingAngle, 0);
        }

        //Sets the facing angle to the object
        if(movement != Vector3.zero && lockFacingToMovement)
        {
            Vector3 currentFacingRotation = objectToRotate.rotation.eulerAngles;
            facingAngle = Vector3.SignedAngle(Vector3.forward, movement, Vector3.up);
            objectToRotate.rotation = Quaternion.Lerp(objectToRotate.rotation, Quaternion.Euler(0, facingAngle, 0), Time.time * turnSpeed * 0.01f);
        }            
    }
    private void FixedUpdate()
    {
        //Apply force to character in movement direction
        if(movement != Vector3.zero)
        {
            rb.AddForce(movement * walkSpeed * runSpeedMultiplier * 10);
        }
    }
}
