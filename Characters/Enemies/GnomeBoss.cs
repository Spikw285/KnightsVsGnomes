using UnityEngine;
//there are two classes at the same time
public class GnomeBoss : Enemy
{
    public GameObject advancedMage;
    public Transform magePosition;

    void Start()
    {
        health = 500f;
        advancedMage.transform.position = magePosition.position;
        advancedMage.GetComponent<GnomeMageBoss>().ActivateMage();
    }

    protected override void Die()
    {
        Debug.Log("GnomeBoss died");
        Destroy(gameObject);
    }
}

public class GnomeMageBoss : GnomeMage
{
    public void ActivateMage()
    {
        // logic for advanced mage being activated on a boss
        Debug.Log("Advanced mage activated!");
    }

    protected override void CastFireball()
    {
        base.CastFireball();
        Debug.Log("GnomeMageBoss cast a powerful fireball!");
    }

    protected override void Die()
    {
        Debug.Log("GnomeMageBoss died");
        base.Die();
    }
}
