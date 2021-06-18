using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftMovementControls : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls playerControls; // Gives each player an instance of controls
    public GameObject fork;
    private Vector3 dir = new Vector3(0, 0, 0);
    private float targetAngle;
    private float lastAngle;
    private Vector3 targetRotation;
    [Range(0, 20)]
    public float thrust;
    [Range(0, 0.1f)]
    public float rotationSpeed;
    private bool rotate;
    private bool reverse;
    private bool isGrounded;
    private bool boostActive;
    [Range(0, 5)]
    public float boostThrust;
    public float boostCapacity;

    void Start() {
        rb = this.GetComponentInChildren<Rigidbody>();
        reverse = false;
        playerControls = new PlayerControls();
    }
    private void OnDrawGizmos() {
        // Include a draw pivot position
    }
    void FixedUpdate() {
        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, 0.2f);
        Debug.DrawRay(this.transform.position, Vector3.down * 0.1f, Color.green);
        if (boostActive) {
            rb.AddRelativeForce(Vector3.forward * boostThrust * Time.deltaTime, ForceMode.Impulse);
            // If boost should be single click
            // boostActive = false;
        }
        if (reverse && isGrounded) {
            rb.AddRelativeForce(Vector3.back * 90 * thrust * Time.deltaTime, ForceMode.Acceleration);
        }
        if (rotate) {
            targetAngle = Vector3.SignedAngle(Vector3.forward, dir, Vector3.up);
            targetRotation = new Vector3 (0, targetAngle, 0);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed));                
            
            if (isGrounded && !reverse) { // Apply forward force when not reversing
                rb.AddRelativeForce(Vector3.forward * 100 * thrust * Time.deltaTime, ForceMode.Acceleration);
                //rb.MovePosition(this.transform.position + Vector3.back * Time.deltaTime);
            }
            else {
                print("Forklift not grounded");
            }
        }
    }

    void Update() {
        // Vertical movement input
        if (Input.GetKey(PlayerControls.upKey)) {
            dir.z = 1;
            rotate = true;
        }
        else if (Input.GetKey(PlayerControls.downKey)) {
            dir.z = -1;
            rotate = true;
        }
        else {
            dir.z = 0;
        }

        // Horizontal movement input
        if (Input.GetKey(PlayerControls.rightKey)) {
            dir.x = 1;
            rotate = true;
        }
        else if (Input.GetKey(PlayerControls.leftKey)) {
            dir.x = -1;
            rotate = true;
        }
        else {
            dir.x = 0;
        }
        
        // Reversing
        if (Input.GetKey(PlayerControls.reverseKey)) {
            reverse = true;
        }
        else {
            reverse = false;
        }
        
        // Detected no movement input
        if (dir == Vector3.zero) {
            rotate = false;
            lastAngle = targetAngle;
        }
        
        // Activate boost input
        if (Input.GetKey(PlayerControls.runKey)) { // Change to getkeydown after boost resource established
            boostActive = true;
        }
    }
}
