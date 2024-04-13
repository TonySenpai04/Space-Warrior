using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAreaController : MonoBehaviour
{
    [SerializeField] private List<CustomArea > areaList;
    [SerializeField] private Planet planet;
    [SerializeField] private GameObject map;
    void Start()
    {
     
        GetArea();
    }

    
    void Update()
    {
        
    }
    public void GetArea()
    {
        CustomArea [] list = GetComponentsInChildren<CustomArea >();
        for (int i=0;i<list.Length;i++)
        {
            areaList.Add(list[i]);
            list[i].SetIndex(i);
        }
 
    }
    public void SetArea(int index)
    {
        map.SetActive(true);
        planet.gameObject.SetActive(true);
        planet.SetActiveArea(index);
    }
    public void UnlockArea(int index)
    {
        areaList[index].Unlock();
    }
}
