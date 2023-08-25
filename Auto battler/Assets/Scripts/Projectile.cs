using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] Enemy target;
    // Update is called once per frame
    void Update()
    {
        if (!target)
            Destroy(gameObject);

        Move();
    }

    public void Move()
    {
        if (target == null)
            Destroy(gameObject);

        Vector3 direction = Vector3.zero;

        try
        {
            direction = (transform.position - target.transform.position).normalized * -1;
        }
        catch
        {

        }

        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() == target)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public int Damage() => damage;

    public void SetTarget(Enemy enemy)
    {
        target = enemy;
    }
}
