using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnController : EnemySpawnControllerBase
{
    public override void Start()
    {
        base.Start();
    }
    public override void InitializeEnemySpawn()
    {
        spawnEnemy = new spawnBoss(player, distanceSpawn, poolEnemies);
    }

    public override void Update()
    {
        base.Update();
    }
}
