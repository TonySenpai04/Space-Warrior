using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : SpawnEnemy
{
    public SpawnMonster(Transform player, float distanceSpawn, List<Enemy> poolMonsters) : base(player, distanceSpawn, poolMonsters)
    {
    }
}
