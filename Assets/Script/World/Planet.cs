using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet : MonoBehaviour
{
    [SerializeField] protected List<Area> areas;
    [SerializeField] protected int index = 0;
    [SerializeField] protected bool isFinish;
    public virtual void Start()
    {
        if(areas == null)
            InitializeAreas();
    }
    public bool IsFinish()
    {
        return areas[index].IsFinish();
    }
    public virtual void Reset()
    {
        InitializeAreas();
    }
    protected void InitializeAreas()
    {
        Area[] areas = GetComponentsInChildren<Area>();
        foreach(var area in areas)
        {
            this.areas.Add(area);
        }
    }
    public void SetActiveArea(int index)
    {
        if (areas == null)
        {
            InitializeAreas();
        }
        this.index=index;
        foreach (var area in areas)
        {
            area.gameObject.SetActive(false);
        }
        
        if (this.index >= 0 && this.index < areas.Count)
        {
            areas[this.index].gameObject.SetActive(true);
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
