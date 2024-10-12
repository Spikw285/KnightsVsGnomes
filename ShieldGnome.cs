using UnityEngine;

public class ShieldGnome : Enemy
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 200f;
    }

    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1); //looking right
        else
            transform.localScale = new Vector3(-1, 1, 1);  //looking left
    }

    protected override void Die()
    {
        Debug.Log("ShieldGnome died");
        Destroy(gameObject);
    }
}
