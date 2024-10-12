using UnityEngine;

public class SpearGnome : Enemy
{
    public float moveSpeed = 2f;
    public float minAttackRange = 1f;
    public float maxAttackRange = 3f;
    private Transform player;
    private bool isGrounded = true;
    public Transform groundCheck;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 50f;
    }

    void Update()
    {
        CheckGround();

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // moving towards player if it has ground underneath and if player's within attack range
        if (isGrounded && distanceToPlayer > maxAttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer <= minAttackRange)
        {
            // can't attack if player is too close
            Debug.Log("SpearGnome is too close to attack");
        }
        else if (distanceToPlayer <= maxAttackRange)
        {
            Attack();
        }

        LookAtPlayer();
    }

    void Attack()
    {
        Debug.Log("SpearGnome attacked!");
        player.GetComponent<Character>().TakeDamage(15f);
    }

    void LookAtPlayer()
    {
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f);
    }

    protected override void Die()
    {
        Debug.Log("SpearGnome died");
        Destroy(gameObject);
    }
}
