using UnityEngine;

public class BugQueen : Boss
{
    //public GameObject projectile;
    //public float damagePercentagePerSecond = 0.03f;
    //public float damageDuration = 5f;
    //[SerializeField] private Transform player;
    //[SerializeField] private Transform pointatk;
    //public override void Awake()
    //{
    //    base.Awake();
    //    player = FindAnyObjectByType<EnemySpawnControllerBase>().player;
       
    //}
    public override void ActiveSkill()
    {
        
    }

    //public  void Attack()
    //{
    //    float distance = transform.position.x - player.transform.position.x;
    //    if (distance <= 8)
    //    {

    //        if (projectile == null || pointatk == null) return;
    //        var MonsterProjectile = Instantiate(projectile.gameObject, pointatk.position, pointatk.rotation);
    //        var projComponent = MonsterProjectile.GetComponent<MonsterProjectile>();
    //        if (projComponent != null)
    //        {
    //            projComponent.damage = 50;
    //        }
    //        var projRb = MonsterProjectile.GetComponent<Rigidbody2D>();

    //        Vector2 leftForce = new Vector2(-1, 0) * 300;
    //        projRb.AddForce(leftForce, ForceMode2D.Force);
    //        Destroy(MonsterProjectile.gameObject, 1f);
    //    }
    //}
}
