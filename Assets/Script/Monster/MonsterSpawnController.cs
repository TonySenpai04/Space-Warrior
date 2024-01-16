using Assets.FantasyMonsters.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController :MonoBehaviour,IMonsterSpawn
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceSpawn;
    [SerializeField] private List<Monster> monstersPrefab;
    [SerializeField] Vector3 currentTransform;
    [SerializeField] private bool canSpawn=true;
    [SerializeField] private Transform poolMonsterPos;
    [SerializeField] private List<Monster> poolMonsters;
    public static MonsterSpawnController instance;
    private void Start()
    {
        instance= this;
        poolMonsters= new List<Monster> ();
        currentTransform =player.transform.position;
        foreach(var item in monstersPrefab)
        {
          var  monster =Instantiate(item, poolMonsterPos.position,Quaternion.identity);
          monster.gameObject.SetActive(false);
          monster.gameObject.transform.SetParent(poolMonsterPos);
          poolMonsters.Add(monster);

        }
    }

    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
           var monster = poolMonsters[Random.Range(0, poolMonsters.Count)];
            monster.body.rotation=Quaternion.Euler(0,0,0);  
            monster.gameObject.SetActive (true);
            if (monster.currentHealth <= 0)
            {
                monster.currentHealth = monster.health;
            }
            monster.Walk();
            monster.transform.position = new Vector3(player.position.x + 15, player.position.y, player.position.z);
           MovementController.instance.StopMove();
           currentTransform = player.position;
           canSpawn = !canSpawn;
        }
       
    }
    public void CanSpawn()
    {
        canSpawn = true;
    }
}
