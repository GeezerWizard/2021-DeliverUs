using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private GameObject targetObject;
    public bool stopMovement;
    ScoreManager scoreManager;
    float speed = 5;
    Vector3 targetPosition;
    Vector3 curPosition;
    Vector3 direction;
    int layerMask = 1 << 10;
    bool attacked = false;
    bool reachedGoal = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        targetObject = GameObject.Find("EnemyGoal");
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
    }
    private void Update()//every frame
    {
        curPosition = transform.position;
        targetPosition = targetObject.transform.position;
    }
    private void FixedUpdate()//every fixed frame
    {
        RaycastHit hit;
        if(!Physics.Linecast(curPosition, targetPosition, out hit, layerMask))
        {
            if (hit.collider == null && !attacked && !reachedGoal && !stopMovement)
            {
                MoveTowardsTarget();
            }
        }
        Debug.DrawLine(curPosition, targetPosition, Color.magenta);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon" && attacked == false)
        {
            StartCoroutine(Attacked());
        }
        if(other.tag == "EnemyGoal" && !reachedGoal)
        {
            col.enabled = false;
            scoreManager.AddEnemiesEscaped();
            reachedGoal = true;
        }
    }

    private void MoveTowardsTarget()//can use states to determine speed to move at, wandering and found goal
    {
        direction = targetPosition - curPosition;
        direction.Normalize();
        transform.forward = direction;
        rb.AddForce(direction * speed * 20);
    }
    
    IEnumerator Attacked()
    {
        attacked = true;
        print("Attacked Called");
        yield return new WaitForSeconds(2);
        attacked = false;
    }
}
