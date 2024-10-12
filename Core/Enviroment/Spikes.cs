using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        Health target = other.GetComponent<Health>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}
