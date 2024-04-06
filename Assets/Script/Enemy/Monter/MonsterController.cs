using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyControllerBase
{
    [SerializeField]private Transform pointatk;
    [SerializeField]private GenericProjectile projectile;
    [SerializeField] private float projectileForce;
    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        float distance = transform.position.x - player.transform.position.x;
        if (distance >= 3f)
        {
            Move();
        }
        else
        {

            enemyData.AttackAnim();

        }


    }
    public override void Attack()
    {
        var MonsterProjectile = Instantiate(projectile.gameObject, pointatk.position, pointatk.rotation);
        var projRb = MonsterProjectile.GetComponent<Rigidbody2D>();
        Vector2 leftForce = new Vector2(-1, 0) * projectileForce;
        projRb.AddForce(leftForce, ForceMode2D.Force);
    }


}
