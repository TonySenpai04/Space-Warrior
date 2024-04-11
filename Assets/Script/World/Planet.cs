using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet : MonoBehaviour
{
    [SerializeField] protected List<EnemySpawnControllerBase> spawnMonsters;
    [SerializeField] protected int index = 0;
   public virtual void Start()
   {
        if (spawnMonsters == null)
        {
            InitializeSpawnMonsterPool();
        }
   }
    public virtual void Reset()
    {
        InitializeSpawnMonsterPool();
    }
    protected void InitializeSpawnMonsterPool()
    {
        EnemySpawnControllerBase[] spawnMonstersBase = GetComponentsInChildren<EnemySpawnControllerBase>();
        foreach(var  spawnMonster in spawnMonstersBase)
        {
            spawnMonsters.Add(spawnMonster);
        }
    }
    public void SetActiveSpawnMonster(int index)
    {
        if (spawnMonsters == null)
        {
            InitializeSpawnMonsterPool();
        }
        this.index=index;
        foreach (EnemySpawnControllerBase spawnMonster in spawnMonsters)
        {
            spawnMonster.gameObject.SetActive(false);
        }
        
        if (this.index >= 0 && this.index < spawnMonsters.Count)
        {
            spawnMonsters[this.index].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Index is out of range!!");
        }
    }
    public virtual void Update()
    {

    }
}
