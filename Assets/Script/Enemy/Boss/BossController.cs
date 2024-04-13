using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyControllerBase
{
   
    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        float distance = transform.position.x - player.transform.position.x;
        if (distance >= 8f)
        {
            Move();
        }
        if (enemyData.currentHealth <= 0)
        {
            isDead = true;

        }
    }
   
}
