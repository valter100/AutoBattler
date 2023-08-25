using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class AutoSkill : MonoBehaviour
{
    [SerializeField] protected float timeBetweenTriggers;
    protected Player player;
    protected EnemyHandler enemyHandler;
    protected float triggerTimer;

    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
        enemyHandler = FindObjectOfType<EnemyHandler>();
    }

    protected abstract void Trigger();
    public virtual void UpdateTimer()
    {
        triggerTimer += Time.deltaTime;

        if(triggerTimer > timeBetweenTriggers)
        {
            triggerTimer = 0;
            Trigger();
        }
    }
}
