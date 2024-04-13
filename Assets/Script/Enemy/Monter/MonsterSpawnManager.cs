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
        for(int i=0; i<planets.Count; i++)
        {
            if (planets[i].isActiveAndEnabled)
            {
                planetsIndex=i; break;
            }
        }

    }
    public bool IsAreaFinish()
    {
        return planets[planetsIndex].IsFinish();
    }

}
