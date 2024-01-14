using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController :MonoBehaviour,IMonsterSpawn
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceSpawn;
    [SerializeField] private List<GameObject> enemyDatas;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] Vector3 currentTransform;
    [SerializeField] private bool canSpawn=true;
    public static MonsterSpawnController instance;
    private void Start()
    {
        instance= this;
        currentTransform =player.transform.position;
    }
    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (player.position.x - currentTransform.x > distanceSpawn && canSpawn)
        {
            enemyPrefab = enemyDatas[Random.Range(0, enemyDatas.Count)];
         
            Instantiate(enemyPrefab, new Vector3(player.position.x + 15, player.position.y , player.position.z), Quaternion.identity);
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
