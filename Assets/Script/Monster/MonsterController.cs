using Assets.FantasyMonsters.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]private Monster monsterData;
    [SerializeField]private Transform player;
    [SerializeField]private float speed;
    [SerializeField]private float health=100;
    public static MonsterController instance;

    private void Start()
    {
        monsterData = GetComponent<Monster>();
        instance = this;
        player = FindAnyObjectByType<PlayerController>().transform;

    }
    private void Update()
    {
        if (transform.position.x - player.transform.position.x > 3f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    public void OnDamge(float dam)
    {
        health-= dam;
        if (health <= 0)
        {
            MovementController.instance.CanMove();
            MonsterSpawnController.instance.CanSpawn();
            Destroy(gameObject);
        }
    }
}
