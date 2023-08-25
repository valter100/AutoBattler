using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    Player player;
    [SerializeField] protected float health;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    public delegate void onEnemyDeath(Enemy enemy);
    public static onEnemyDeath death;

    public Vector3 Position() => transform.position;

    //public float DistanceToPlayer() => Vector3.Distance(transform.position, player.transform.position);

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void Move()
    {
        Vector3 direction = (transform.position - player.transform.position).normalized * -1;

        transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //EnemyHandler.RemoveEnemy(this);
        death?.Invoke(this);
        Destroy(gameObject);
    }

    public virtual void KnockBack()
    {

    }
}
