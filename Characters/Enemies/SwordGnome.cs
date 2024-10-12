using UnityEngine;

public class SwordGnome : Enemy
{
    public float moveSpeed = 2f;
    public float attackRange = 1f;
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

        // moving towards player if it has ground underneath
        if (isGrounded && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        LookAtPlayer();
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
        Debug.Log("SwordGnome died");
        Destroy(gameObject);
    }
}
