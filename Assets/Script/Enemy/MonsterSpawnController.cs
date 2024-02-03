using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController :EnemySpawnController
{

    public static MonsterSpawnController instance;
    public override void Start()
    {
        instance= this;
        base.Start();
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
