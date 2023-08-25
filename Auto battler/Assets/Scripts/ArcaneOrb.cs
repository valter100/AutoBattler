using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneOrb : AutoSkill
{
    [SerializeField] int damage;
    [SerializeField] Projectile projectile;

    protected override void Trigger()
    {
        Enemy closestEnemy = enemyHandler.GetClosestEnemy(player.transform.position);
        if (closestEnemy)
        {
            GameObject projectileObject = Instantiate(projectile.gameObject, player.transform.position, Quaternion.identity);
            projectileObject.GetComponent<Projectile>().SetTarget(closestEnemy);
            Debug.Log("Arcane Orb triggered");
        }

    }

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        SetProjectileDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProjectileDamage(int damage)
    {
        projectile.SetDamage(damage);
    }
}
