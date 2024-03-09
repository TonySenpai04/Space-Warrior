using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class EnemySpawnControllerBase : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public float distanceSpawn;
    [SerializeField] public List<Enemy> enemiesPrefab;
    [SerializeField] public Transform poolEnemiesPos;
    [SerializeField] public List<Enemy> poolEnemies;
    public ISpawn spawnEnemy;
    public virtual  void Start()
    {
       
        InitializeEnemyPool();
        InitializeEnemySpawn();
    }
    public virtual void InitializeEnemySpawn()
    {
       
    }
    public virtual void InitializeEnemyPool()
    {
        poolEnemies = new List<Enemy>();
        foreach (var item in enemiesPrefab)
        {
            var enemy = Instantiate(item, poolEnemiesPos.position, Quaternion.identity);
            enemy.gameObject.SetActive(false);
            enemy.gameObject.transform.SetParent(poolEnemiesPos);
            poolEnemies.Add(enemy);

        }
    }
    public virtual void Update()
    {
        Spawn();
        
    }
    public virtual void Spawn()
    {
        spawnEnemy.Spawn();

    }
    public virtual void CanSpawn()
    {
        ICanSpawn canSpawn = (ICanSpawn)spawnEnemy;
        canSpawn.CanSpawn();
    }
}
