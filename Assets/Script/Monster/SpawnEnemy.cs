using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : ISpawn,ICanSpawn
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceSpawn;
    [SerializeField] Vector3 currentTransform;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private List<Monster> poolMonsters;
    public SpawnEnemy(Transform player, float distanceSpawn, List<Monster> poolMonsters)
    {
        this.player = player;
        this.distanceSpawn = distanceSpawn;
        this.poolMonsters = poolMonsters;
        currentTransform=player.transform.position;
    }
    public void Spawn()
    {
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
            var monster = poolMonsters[Random.Range(0, poolMonsters.Count)];
            monster.body.rotation = Quaternion.Euler(0, 0, 0);
            monster.gameObject.SetActive(true);
            if (monster.currentHealth <= 0)
            {
                monster.currentHealth = monster.health;
            }

            monster.Walk();
            monster.transform.position = new Vector3(player.position.x + 15, player.position.y, player.position.z);
            currentTransform = player.position;
            canSpawn = !canSpawn;
        }
    }
    public void CanSpawn()
    {
        canSpawn = true;
    }
}
