using System.Collections.Generic;
using UnityEngine;

internal class spawnBoss : SpawnEnemy
{
    private int nextMonsterIndex=0;
    public spawnBoss(Transform player, float distanceSpawn, List<Enemy> poolMonsters) : base(player, distanceSpawn, poolMonsters)
    {
       
    }
    public override  void Spawn()
    {
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
            var monster = poolMonsters[nextMonsterIndex];

            SetupMonster(monster);
            monster.transform.position = new Vector3(player.position.x + 15, player.position.y, player.position.z);
            nextMonsterIndex = (nextMonsterIndex + 1) % poolMonsters.Count;

            currentTransform = player.position;
            canSpawn=!canSpawn; 
          
        }

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