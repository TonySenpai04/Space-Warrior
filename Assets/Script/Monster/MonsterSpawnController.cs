using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController :MonoBehaviour,ISpawn
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceSpawn;
    [SerializeField] private List<Monster> monstersPrefab;
    [SerializeField] private Transform poolMonsterPos;
    [SerializeField] private List<Monster> poolMonsters;
    private ISpawn spawnMonster;
    public static MonsterSpawnController instance;
    private void Start()
    {
        instance= this;
        poolMonsters= new List<Monster> ();
        foreach(var item in monstersPrefab)
        {
          var  monster =Instantiate(item, poolMonsterPos.position,Quaternion.identity);
          monster.gameObject.SetActive(false);
          monster.gameObject.transform.SetParent(poolMonsterPos);
          poolMonsters.Add(monster);

        }
        spawnMonster = new SpawnEnemy(player, distanceSpawn, poolMonsters); ;
    }

    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        spawnMonster.Spawn();
       
    }
    public void CanSpawn()
    {
        ICanSpawn canSpawn = (ICanSpawn)spawnMonster;
        canSpawn.CanSpawn();
    }
}
