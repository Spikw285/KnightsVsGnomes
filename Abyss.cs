using UnityEngine;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health target = other.GetComponent<Health>();
        if (target != null)
        {
            target.TakeDamage(target.maxHealth); // instadeath
        }
    }
}
