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
        timer = Time.time;
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
            currentEnemy = poolMonsters[nextMonsterIndex];
            SetupEnemy(currentEnemy);
            currentEnemy.transform.position = new Vector3(player.position.x + 25, player.position.y, player.position.z);
            nextMonsterIndex = (nextMonsterIndex + 1) % poolMonsters.Count;
            currentTransform = player.position;
            canSpawn=!canSpawn; 
          
        }
        CanSpawn();
    }

}