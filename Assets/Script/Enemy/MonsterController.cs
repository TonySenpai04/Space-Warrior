using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyControllerBase
{
    public static MonsterController instance;
    public void Awake()
    {
        instance = this; 
    }
  
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
        if (distance <= 12f && enemyData.currentHealth > 0)
        {
            ShootingController.instance.StartShooting();
            if (enemyData.enemyType == Enemy.EnemyType.Fly)
            {
                ShootingController.instance.LookAtMonster(new Vector3(this.transform.position.x, transform.position.y + 1.25f, transform.position.z));
            }
            else
            {
                ShootingController.instance.LookAtMonster(this.transform.position);
            }
            MovementController.instance.StopMove();
            AnimationController.instance.Idle();
        }
    }
    public override void TakeDamage(float dam)
    {
        enemyData.currentHealth -= (int)dam;
        var floatingText = Instantiate(floatingTextPrefab.gameObject, new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1),
            Random.Range(transform.position.y + 2.5f, transform.position.y + 3f), transform.position.z), Quaternion.identity, transform);
        floatingText.GetComponent<TextMesh>().text = ((int)dam).ToString();
        if (enemyData.currentHealth <= 0)
        {
            MovementController.instance.CanMove();
            MonsterSpawnController.instance.CanSpawn();
            ShootingController.instance.StopShooting();
            AnimationController.instance.Move();
            enemyData.Die();
            StartCoroutine(Death());
        }
    }
    public override IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        if (GetComponent<LootBag>())
        {
            GetComponent<LootBag>().CreateItem(this.transform.position);
        }
        gameObject.SetActive(false);
    }
}
