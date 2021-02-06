using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //References
    Rigidbody2D rb;
    public Transform targetObject;
    //Variables
    public float speed;
    Vector2 targetPosition;
    Vector2 curPosition;
    Vector2 direction;
    int layerMask = 1 << 10;
    //States
    bool attacked;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attacked = false;
    }
    private void Update()
    {
        curPosition = transform.position;
        targetPosition = targetObject.position;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Linecast(curPosition, targetPosition, layerMask);
        Debug.DrawLine(curPosition, targetPosition, Color.magenta);
        if (hit.collider == null && !attacked)
        {
            MoveTowardsTarget();
        }
        else
        {
            StopMoving();
        }
    }
    private void OnColliderEnter(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            attacked = true;
        }
    }
    private void FindGoal()//stops moving and looks for goal
    {
        //Stop and look animation
    }
    private void DetectGoal()
    {
        //Detect goal animation. Time taken to detect goal, use coroutine?
    }
    private void FoundGoal()//excitement!
    {
        //Found goal animation. 
    }
    private void LookingForNextTarget()//processing...
    {
        
    }
    private void MoveTowardsTarget()//can use states to determine speed to move at, wandering and found goal
    {
        direction = targetPosition - curPosition;
        direction.Normalize();
        rb.AddForce(direction * speed * 20);
    }
    private void StopMoving()
    {
        //rb.velocity = Vector2.zero;
    }
}
