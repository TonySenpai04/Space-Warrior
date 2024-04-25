using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyControllerBase
{
    [SerializeField]private Transform pointatk;
    [SerializeField]private GenericProjectile projectile;
    [SerializeField] private float projectileForce;
    [SerializeField] private int damage;
    [SerializeField] private float distanceMove=3f;

    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        float distance = transform.position.x - player.transform.position.x;
        if (distance >= distanceMove)
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
        if (projectile == null || pointatk == null) return;
        var MonsterProjectile = Instantiate(projectile.gameObject, pointatk.position, pointatk.rotation);
        var projComponent = MonsterProjectile.GetComponent<MonsterProjectile>();
        if (projComponent != null)
        {
            projComponent.damage = damage; 
        }
        var projRb = MonsterProjectile.GetComponent<Rigidbody2D>();

        Vector2 leftForce = new Vector2(-1, 0) * projectileForce;
        projRb.AddForce(leftForce, ForceMode2D.Force);
        Destroy(MonsterProjectile.gameObject, 1f);
    }


}
