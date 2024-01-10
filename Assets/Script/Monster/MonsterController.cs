using Assets.FantasyMonsters.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]private Monster monsterData;
    [SerializeField]private Transform player;
    [SerializeField] private float speed;


    private void Start()
    {
        monsterData = GetComponent<Monster>();
        player = FindAnyObjectByType<PlayerController>().transform;

    }
    private void Update()
    {
        if (transform.position.x - player.transform.position.x > 3f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
