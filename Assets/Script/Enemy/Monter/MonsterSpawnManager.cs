using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private List<Planet> planets;
    public static MonsterSpawnManager instance;
    [SerializeField] private int planetsIndex = 0;
   
    void Start()
    {
        instance = this;
        //InitializeSpawnMonsterPool();
       // SetActiveSpawnMonster(index);

    }


    //protected void InitializeSpawnMonsterPool()
    //{
    //    spawnMonsters = new List<EnemySpawnControllerBase>(GetComponentsInChildren<EnemySpawnControllerBase>());
    //}
    //protected void SetActiveSpawnMonster(int index)
    //{
    //    foreach (EnemySpawnControllerBase spawnMonster in spawnMonsters)
    //    {
    //        spawnMonster.gameObject.SetActive(false);
    //    }

    //    if (index >= 0 && index < spawnMonsters.Count)
    //    {
    //        spawnMonsters[index].gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        Debug.LogError("Index is out of range!!");
    //    }
    //}
    //public void SetLevelSpawn(int level)
    //{
    //    switch (level)
    //    { 
    //        case 10:
    //            index +=1;
    //            SetActiveSpawnMonster(index);
    //            break;
    //        case 20:
    //            index += 1;
    //            SetActiveSpawnMonster(index);
    //            break;
    //        case 30:
    //            index += 1;
    //            SetActiveSpawnMonster(index);
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //public void SetMapSpawn(Map map)
    //{
    //    int mapIndex = (int)map.planet * 100 + (int)map.area;

    //    if (mapIndex >= 0 && mapIndex < spawnMonsters.Count)
    //    {
    //        index = mapIndex;
    //        SetActiveSpawnMonster(index);
    //    }
    //    else
    //    {
    //        Debug.LogError("Map index is out of range!!");
    //    }
    //}


}
