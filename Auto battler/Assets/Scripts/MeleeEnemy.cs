using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Projectile>())
        {
            TakeDamage(other.gameObject.GetComponent<Projectile>().Damage());
        }
        else if(other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
