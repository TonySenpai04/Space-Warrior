using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnController : EnemySpawnController
{
    public static BossSpawnController instance; 
    public override void Start()
    {
        instance = this;
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
