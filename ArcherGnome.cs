using UnityEngine;

public class ArcherGnome : Enemy
{
    public GameObject arrowPrefab;
    public float attackRange = 10f;
    public float moveSpeed = 2f;
    private Transform player;
    private bool isGrounded = true;
    public Transform groundCheck;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 40f;
    }

    void Update()
    {
        CheckGround();
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (isGrounded && distanceToPlayer > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer <= attackRange)
        {
            if (IsClearShot())
            {
                ShootArrow();
            }
        }

        LookAtPlayer();
    }

    bool IsClearShot()
    {
        // check for not hitting other gnomes
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.position - transform.position).normalized, attackRange);
        return hit.collider == null || hit.collider.CompareTag("Player");
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Projectile projectile = arrow.GetComponent<Projectile>();
        projectile.speed = 7f;
        projectile.damage = 8f;
        Debug.Log("ArcherGnome shot an arrow!");
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
        Debug.Log("ArcherGnome died");
        Destroy(gameObject);
    }
}
