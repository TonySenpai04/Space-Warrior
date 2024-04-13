using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private List<Planet> planets;
    public static PlanetManager instance;
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
    public Area GetCurrentArea()
    {
        return planets[planetsIndex].GetCurrentArea(); ;
    }
    public void UnlockNextArea()
    {
        planets[planetsIndex].UnlockNextArea();
    }
    public void NextArea()
    {
        planets[planetsIndex].NextArea();
    }


}
