using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // taking damage to player
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject); // destroying projectile after hit
        }
        else if (other.CompareTag("Enemy"))
        {
            // taking damage to enemy if required
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); // destroying projectile after hit
        }
    }
}
