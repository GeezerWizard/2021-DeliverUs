using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControls : MonoBehaviour
{
    // References
    private Rigidbody rb;
    public GameObject fork;
    private Vector3 dir = new Vector3(0, 0, 0);
    [Range(0, 50)]
    public float thrust;
    [Range(0, 0.1f)]
    public float rotationSpeed;
    private bool moving;
    private Vector3 maxForkHeight = new Vector3(0, 2, 0);
    private Vector3 minForkHeight;
    public float forkSpeed;

    void Start()
    {
        rb = this.GetComponentInChildren<Rigidbody>();
        minForkHeight = fork.transform.localPosition;
    }
    void FixedUpdate()
    {
        if (moving)
        {
            float targetAngle = Vector3.SignedAngle(Vector3.forward, dir, Vector3.up);
            Vector3 targetRotation = new Vector3 (0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed);
            rb.AddRelativeForce(Vector3.forward * thrust, ForceMode.Acceleration);
        }
        else
        {
            moving = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(PlayerControls.upKey))
        {
            dir.z = 1;
            moving = true;
        }
        else if (Input.GetKey(PlayerControls.downKey))
        {
            dir.z = -1;
            moving = true;
        }
        else 
        {
            dir.z = 0;
        }
        if (Input.GetKey(PlayerControls.rightKey))
        {
            dir.x = 1;
            moving = true;
        }
        else if (Input.GetKey(PlayerControls.leftKey))
        {
            dir.x = -1;
            moving = true;
        }
        else
        {
            dir.x = 0;
        }
        if (dir == Vector3.zero)
        {
            moving = false;
        }
        if (Input.GetKey(PlayerControls.carryKey))
        {
            if (fork.transform.position.y < 2)
            {
                fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, maxForkHeight, forkSpeed);
            }
        }
        else
        {
            fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, minForkHeight, forkSpeed);
        }
    }
}
