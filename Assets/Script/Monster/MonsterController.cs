using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyController
{
    public static MonsterController instance;
    public override void Start()
    {
        base.Start();
        instance = this;
    }
    //[SerializeField]private Enemy monsterData;
    //[SerializeField]private Transform player;
    //[SerializeField]private float speed;
    //[SerializeField]private GameObject floatingTextPrefab;
    //public static MonsterController instance;

    //private void Start()
    //{
    //    monsterData = GetComponent<Enemy>();
    //    instance = this;
    //    player = FindAnyObjectByType<PlayerController>().transform;
    //    monsterData.Walk();

    //}
    //private void Update()
    //{
    //    if (transform.position.x - player.transform.position.x >= 5f)
    //    {
    //        transform.Translate(Vector3.left * speed * Time.deltaTime);
    //    }
    //    if (transform.position.x - player.transform.position.x >=9f)
    //    {
    //        ShootingController.instance.StartShooting();
    //        ShootingController.instance.LookAtMonster(this.transform);
    //        AnimationController.instance.Idle();
    //    }
    //}
    //public void OnDamge(float dam)
    //{
    //   monsterData.currentHealth-= dam;
    //    var floatingText = Instantiate(floatingTextPrefab.gameObject,new Vector3(Random.Range( transform.position.x-1, transform.position.x + 1), 
    //        Random.Range(transform.position.y+2.5f, transform.position.y + 3f),transform.position.z), Quaternion.identity,transform);
    //    floatingText.GetComponent<TextMesh>().text = dam.ToString();
    //    if (monsterData.currentHealth <= 0)
    //    {
    //        MovementController.instance.CanMove();
    //        MonsterSpawnController.instance.CanSpawn();
    //        ShootingController.instance.StopShooting();
    //        AnimationController.instance.Move();
    //        monsterData.Die();
    //        StartCoroutine(Death());
    //    }
    //}
    //IEnumerator Death()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.SetActive(false);
    //}
}
