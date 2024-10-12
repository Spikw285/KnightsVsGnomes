using UnityEngine;

public class GnomeMage : Enemy
{
    public GameObject fireballPrefab;
    public float attackRange = 8f;
    public float moveSpeed = 2f;
    private Transform player;
    private bool isGrounded = true;
    public Transform groundCheck;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 60f;
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
            CastFireball();
        }

        LookAtPlayer();
    }

    void CastFireball()
{
    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    Projectile projectile = fireball.GetComponent<Projectile>();
    projectile.speed = 5f;
    projectile.damage = 10f;
    Debug.Log("GnomeMage cast a fireball!");
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
        Debug.Log("GnomeMage died");
        Destroy(gameObject);
    }
}
