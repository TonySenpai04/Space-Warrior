using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : ISpawn,ICanSpawn,IGetCurentEnemy
{
    protected Transform player;
    protected float distanceSpawn;
    protected Vector3 currentTransform;
    protected bool canSpawn = true;
    protected List<Enemy> poolMonsters;
    protected Enemy currentEnemy;
    protected float timer;
    protected Vector3 startPos;
    protected float startTime;
    public SpawnEnemy(Transform player, float distanceSpawn, List<Enemy> poolMonsters)
    {
        this.player = player;
        this.distanceSpawn = distanceSpawn;
        this.poolMonsters = poolMonsters;
        currentTransform = player.transform.position;
        startPos=player.transform.position;
        startTime=Time.time;
    }
    public virtual Enemy GetCurrentEnemy()
    {
        return currentEnemy;
    }
    public virtual void Spawn()
    {
        if (!player.GetComponentInChildren<CharacterStats>().isDead)
        {
            timer = Time.time - startTime;
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
        else
        {
            if (currentEnemy != null)
            {
                currentEnemy.gameObject.SetActive(false);
            }
            currentEnemy = null;

        }
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
        if (enemy.body != null)
        {
            enemy.body.rotation = Quaternion.Euler(0, 0, 0);
        }
        enemy.Head.transform.rotation = Quaternion.Euler(0, 0, 0);

        enemy.health = enemy.baseHealth + 0.7f * timer;
        enemy.currentHealth = enemy.health;
        enemy.gameObject.SetActive(true);

        enemy.WalkAnim();
    }
    public virtual void Restart()
    {
        currentTransform = startPos;
        canSpawn = true;
        currentEnemy = null;
        timer = 0f;
        startTime = Time.time;
    }
}
