using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyTypes = new List<Enemy>();
    [SerializeField] float timeBetweenEnemySpawn;
    [SerializeField] Collider spawnArea;
    float enemySpawnTimer;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();

    private void OnEnable()
    {
        Enemy.death += RemoveEnemy;
    }

    private void OnDisable()
    {
        Enemy.death -= RemoveEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer += Time.deltaTime;

        if(enemySpawnTimer > timeBetweenEnemySpawn )
        {
            enemySpawnTimer = 0;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Enemy enemyToSpawn = enemyTypes[Random.Range(0, enemyTypes.Count)];

        Vector3 spawnPos = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            0,
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));

        Enemy spawnedEnemy = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);

        enemies.Add(spawnedEnemy);
    }

    public Enemy GetClosestEnemy(Vector3 playerPos)
    {
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerPos);
            if (distanceToPlayer < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distanceToPlayer;
            }
        }

        return closestEnemy;
    }

    public void RemoveEnemy(Enemy removedEnemy)
    {
        enemies.Remove(removedEnemy);
    }
}
