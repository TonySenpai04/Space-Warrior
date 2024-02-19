using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : ISpawn,ICanSpawn
{
    protected Transform player;
    protected float distanceSpawn;
    protected Vector3 currentTransform;
    protected bool canSpawn = true;
    protected List<Enemy> poolMonsters;
    protected Enemy currentEnemy;
    public SpawnEnemy(Transform player, float distanceSpawn, List<Enemy> poolMonsters)
    {
        this.player = player;
        this.distanceSpawn = distanceSpawn;
        this.poolMonsters = poolMonsters;
        currentTransform=player.transform.position;
    }
    public virtual void Spawn()
    {
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
            currentEnemy = poolMonsters[Random.Range(0, poolMonsters.Count)];
            SetupEnemy(currentEnemy);
            currentEnemy.transform.position = new Vector3(player.position.x + 15, player.position.y, player.position.z);
            currentTransform = player.position;
            canSpawn = !canSpawn;

        }
        CanSpawn();
    }
    public virtual void CanSpawn()
    {
        if (currentEnemy != null && currentEnemy.currentHealth <= 0)
        {
            canSpawn = true;
        }
    }
    public virtual void SetupEnemy(Enemy enemy)
    {
        enemy.body.rotation = Quaternion.Euler(0, 0, 0);
        enemy.Head.transform.rotation = Quaternion.Euler(0, 0, 0);
        enemy.gameObject.SetActive(true);

        if (enemy.currentHealth <= 0)
        {
            enemy.currentHealth = enemy.health;
        }

        enemy.Walk();
    }
}
