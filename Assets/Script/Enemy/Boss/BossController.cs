using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyControllerBase
{

    protected float distance;
    private bool isAttacking = false;
    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
         distance = transform.position.x - player.transform.position.x;
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
