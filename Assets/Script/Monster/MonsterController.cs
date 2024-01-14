using Assets.FantasyMonsters.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]private Monster monsterData;
    [SerializeField]private Transform player;
    [SerializeField]private float speed;
    [SerializeField]private float health=100;
    [SerializeField] private GameObject floatingTextPfb;
    public static MonsterController instance;

    private void Start()
    {
        monsterData = GetComponent<Monster>();
        instance = this;
        player = FindAnyObjectByType<PlayerController>().transform;

    }
    private void Update()
    {
        if (transform.position.x - player.transform.position.x >= 6f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x - player.transform.position.x >=9f)
        {
            ShootingController.instance.IsShooting();
            ShootingController.instance.LookAtMonster(this.transform);
            AnimationController.instance.Idle();
        }
    }
    public void OnDamge(float dam)
    {
        health-= dam;
        var floatingText = Instantiate(floatingTextPfb.gameObject,new Vector3( transform.position.x,transform.position.y+2.5f,transform.position.z), Quaternion.identity,transform);
        floatingText.GetComponent<TextMesh>().text = dam.ToString();
        if (health <= 0)
        {
            MovementController.instance.CanMove();
            MonsterSpawnController.instance.CanSpawn();
            ShootingController.instance.StopShooting();
            AnimationController.instance.Move();
            Destroy(gameObject);
        }
    }
}
