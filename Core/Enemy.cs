using UnityEngine;
//a generalized class for enemies
public class Enemy : Health {
    public float moveSpeed = 2f;
    public Transform target;
    protected virtual void Update() {
        if (target != null) {
            //going towards player
            MoveTowardsPlayer();
        }
    }
    protected virtual void MoveTowardsPlayer() {
        //movements for enemy towards player
        Vector3 direction = (target.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}