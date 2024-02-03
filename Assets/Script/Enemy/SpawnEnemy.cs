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
            var enemy = poolMonsters[Random.Range(0, poolMonsters.Count)];
            SetupMonster(enemy);
            enemy.transform.position = new Vector3(player.position.x + 15, player.position.y, player.position.z);
            currentTransform = player.position;
            canSpawn = !canSpawn;
        }
    }
    public virtual void CanSpawn()
    {
        canSpawn = true;
    }
    private void SetupMonster(Enemy monster)
    {
        monster.body.rotation = Quaternion.Euler(0, 0, 0);
        monster.gameObject.SetActive(true);

        if (monster.currentHealth <= 0)
        {
            monster.currentHealth = monster.health;
        }

        monster.Walk();
    }
}
