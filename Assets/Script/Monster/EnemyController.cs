using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy monsterData;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject floatingTextPrefab;
   


    public virtual void Start()
    {
        monsterData = GetComponent<Enemy>();
        player = FindAnyObjectByType<PlayerController>().transform;
        monsterData.Walk();

    }
    public virtual void Update()
    {
        float distance = transform.position.x - player.transform.position.x;
        if (distance >= 5f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (distance<=12f && monsterData.currentHealth>0)
        {
            ShootingController.instance.StartShooting();
            if (monsterData.enemyType == Enemy.EnemyType.Fly)
            {
                ShootingController.instance.LookAtMonster(new Vector3( this.transform.position.x,transform.position.y+1.25f,transform.position.z));
            }
            else
            {
                ShootingController.instance.LookAtMonster(this.transform.position);
            }
            MovementController.instance.StopMove();
            AnimationController.instance.Idle();
        }
    }
    public virtual void OnDamge(float dam)
    {
        monsterData.currentHealth -= dam;
        var floatingText = Instantiate(floatingTextPrefab.gameObject, new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1),
            Random.Range(transform.position.y + 2.5f, transform.position.y + 3f), transform.position.z), Quaternion.identity, transform);
        floatingText.GetComponent<TextMesh>().text = dam.ToString();
        if (monsterData.currentHealth <= 0)
        {
            MovementController.instance.CanMove();
            MonsterSpawnController.instance.CanSpawn();
            ShootingController.instance.StopShooting();
            AnimationController.instance.Move();
            monsterData.Die();
            StartCoroutine(Death());
        }
    }
    public virtual IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
