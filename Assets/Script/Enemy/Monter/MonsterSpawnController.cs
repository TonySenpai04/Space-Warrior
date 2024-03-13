using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController :EnemySpawnControllerBase
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void InitializeEnemySpawn()
    {
        spawnEnemy = new SpawnMonster(player, distanceSpawn, poolEnemies);
    }

    public override void Update()
    {
        base.Update();
    }

}
