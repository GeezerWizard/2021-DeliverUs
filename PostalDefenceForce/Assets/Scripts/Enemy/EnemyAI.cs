using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private GameObject targetObject;
    private EnemyHealth enemyHealth;
    public bool stopMovement;
    ScoreManager scoreManager;
    public float speed;
    Vector3 targetPosition;
    Vector3 curPosition;
    Vector3 direction;
    int layerMask = 1 << 10;
    bool attacked = false;
    bool foundGoal;
    bool reachGoal = false;
    bool needNewTarget;

    private void Start()
    {
        needNewTarget = true;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        targetObject = GameObject.Find("EnemyGoal");
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Update()//every frame
    {
        curPosition = transform.position;
        if (needNewTarget)
        {
            SetTargetPosition(curPosition - Vector3.left);
        }
        else if (!needNewTarget && !attacked)
        {
            MoveInDirection();
        }
    }
    private void FixedUpdate()//every fixed frame
    {
        Debug.DrawLine(curPosition, targetPosition, Color.magenta);
        LookForGoal();
    }


    private void LookForGoal() //constantly looking at goal
    {
        RaycastHit hit;
        if (!Physics.Linecast(curPosition, targetObject.transform.position, out hit, layerMask)) //if it doesnt collide with wall
        {
            if (!reachGoal && !foundGoal) //if not being blocked
            {
                StartCoroutine(GoalFound());
                SetTargetPosition(targetObject.transform.position);
                foundGoal = true;
            }
        }
        else //if it does collide with wall
        {
            foundGoal = false;
            needNewTarget = true;
        }
    }

    private void LookForDirection()
    {
        Vector3 southEastDir = curPosition + new Vector3(1, -1, 0);
        Vector3 southWestDir = curPosition + new Vector3(-1, -1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && attacked == false)
        {
            StartCoroutine(Attacked());
            enemyHealth.ChangeHealth(-1);
        }
        if (other.tag == "EnemyGoal" && !reachGoal)
        {
            scoreManager.AddEnemiesEscaped();
            StartCoroutine(ReachedGoal());
        }
    }

    private void SetTargetPosition(Vector3 tarPos)
    {
        targetPosition = tarPos;
        needNewTarget = false;
    }

    private void MoveInDirection()
    {
        direction = targetPosition - curPosition;
        direction.Normalize();
        transform.forward = direction;
        rb.AddForce(direction * speed * 20);
    }

    IEnumerator Attacked()
    {
        attacked = true;
        yield return new WaitForSeconds(2);
        attacked = false;
    }
    IEnumerator GoalFound()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator ReachedGoal()
    {
        reachGoal = true;
        enemyHealth.SetDrag(8f);
        enemyHealth.SetBodyCrouch(true);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
