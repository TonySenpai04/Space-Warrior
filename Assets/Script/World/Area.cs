using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour, IObserver
{
    [SerializeField] protected EnemySpawnControllerBase spawnMonsters;
    [SerializeField] protected EnemySpawnControllerBase spawnBoss;
    [SerializeField] protected int index = 0;
    [SerializeField] protected bool isFinish;
    [SerializeField] private bool isBoss;
    [SerializeField] private GameObject bossNotification;
    [SerializeField] private bool isShowbossNotification = true;
    [SerializeField] private bool isShowVictoryPanel = true;
    [SerializeField] private bool isUnlock;
    [SerializeField] private Victory victoryPanel;
    [SerializeField] public bool isRun=false;
    [SerializeField] private Timer timer;
    [SerializeField] private int stars;
    [SerializeField] private Planet planet;

    public virtual void Start()
    {
        planet=GetComponentInParent<Planet>();  
        if (spawnMonsters == null)
        {
            InitializeSpawnMonsterPool();
        }
    }
    public bool GetUnlock()
    {
        return this.isUnlock;
    }
    public void Unlock()
    {
        this.isUnlock = true;
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
    public int GetStar()
    {
        return this.stars;
    }

    public  void FixedUpdate()
    {
        
            if (isUnlock && isRun)
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
                else
                {
                    if (isShowVictoryPanel)
                    {
                        victoryPanel.gameObject.SetActive(true);


                        if (timer.GetTimer() < 600)
                        {
                            stars = 3;
                        }
                        victoryPanel.SetStar(stars);

                    }

                }
            }
            else
            {

                victoryPanel.gameObject.SetActive(false);

            }

    }
    public void Active()
    {
        this.gameObject.SetActive(true);
        spawnMonsters.gameObject.SetActive(true);
        spawnBoss.gameObject.SetActive(true);
        isRun = true;
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
    public void Restart()
    {
        spawnMonsters.Restart();
        spawnBoss.Restart();
        isFinish = false;
        isBoss = false;
        SkillManager.instance.Restart();


    }

    public void UpdateObserver()
    {
        Restart();
    }
}
