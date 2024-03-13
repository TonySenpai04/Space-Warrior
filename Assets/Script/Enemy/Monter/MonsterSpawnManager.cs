using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnControllerBase> spawnMonsters;
    public static MonsterSpawnManager instance;
    [SerializeField] private int index=0;
    
    void Start()
    {
        instance = this;
        InitializeSpawnMonsterPool();
        SetActiveSpawnMonster(index);

    }


    protected void InitializeSpawnMonsterPool()
    {
        spawnMonsters = new List<EnemySpawnControllerBase>(GetComponentsInChildren<EnemySpawnControllerBase>());
    }
    protected void SetActiveSpawnMonster(int index)
    {
        foreach (EnemySpawnControllerBase spawnMonster in spawnMonsters)
        {
            spawnMonster.gameObject.SetActive(false);
        }

        if (index >= 0 && index < spawnMonsters.Count)
        {
            spawnMonsters[index].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Index is out of range!!");
        }
    }
    public void SetLevelSpawn(int level)
    {
        switch (level)
        { 
            case 10:
                index +=1;
                SetActiveSpawnMonster(index);
                break;
            case 20:
                index += 1;
                SetActiveSpawnMonster(index);
                break;
            case 30:
                index += 1;
                SetActiveSpawnMonster(index);
                break;
            default:
                break;
        }
    }

}
