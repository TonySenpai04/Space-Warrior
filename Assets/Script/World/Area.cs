using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] protected EnemySpawnControllerBase spawnMonsters;
    [SerializeField] protected EnemySpawnControllerBase spawnBoss;
    [SerializeField] protected int index = 0;
    [SerializeField] protected bool isFinish;
    [SerializeField] private bool isBoss;
    [SerializeField] private GameObject bossNotification;
    [SerializeField] private bool isShowbossNotification = true;
    public virtual void Start()
    {
        if (spawnMonsters == null)
        {
            InitializeSpawnMonsterPool();
        }
    }
    public bool IsFinish()
    {
        return isFinish;
    }
    public virtual void Reset()
    {
        InitializeSpawnMonsterPool();
    }
    protected void InitializeSpawnMonsterPool()
    {
        EnemySpawnControllerBase[] enemySpawnControllers=GetComponentsInChildren<EnemySpawnControllerBase>();
        spawnMonsters = enemySpawnControllers[0];
        spawnBoss = enemySpawnControllers[1];
    }


    public  void Update()
    {
        if (!isFinish)
        {
            if (!isBoss)
            {
                spawnMonsters.Spawn();
                spawnBoss.Spawn();
                if (spawnBoss.GetCurrentEnemy() != null)
                {
                    isBoss = true;
                }
            }
            else
            {

                StartCoroutine(ShowBossNotification());
                if (spawnBoss.GetCurrentEnemy() != null)
                {
                    if (spawnBoss.GetCurrentEnemy().GetComponent<EnemyControllerBase>().IsDead())
                        isFinish = true;
                }


            }
        }

    }
    private IEnumerator ShowBossNotification()
    {
        if (isShowbossNotification)
        {
            bossNotification.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        isShowbossNotification = false;
        bossNotification.SetActive(false);
    }


}
