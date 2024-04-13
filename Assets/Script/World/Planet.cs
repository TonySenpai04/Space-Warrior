using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Planet : MonoBehaviour
{
    [SerializeField] protected List<Area> areas;
    [SerializeField] protected int index = 0;
    [SerializeField] protected bool isFinish;
    [SerializeField] protected  Timer timer;
    [SerializeField] protected WeaponControllerBase weaponController;
    public virtual void Start()
    {
        if(areas == null)
            InitializeAreas();
        
    }
    public Area GetCurrentArea()
    {
        return areas[index];
    }
    public bool IsFinish()
    {
        return areas[index].IsFinish();
    }
    public virtual void Reset()
    {
        InitializeAreas();
    }
    public List<Area> GetAreas()
    {
        return areas;
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
            areas[this.index].Active();
        }
        else
        {
            Debug.Log("Index is out of range!!");
        }
    }
    public void UnlockNextArea()
    {
        if (areas[index].IsFinish())
        {
            areas[index].isRun = false;
            index++;
            areas[index].Unlock();

        }
    }
    public void NextArea()
    {
        GridManager.instance.GetCurrentGrid().Restart();
        timer.Restart();
        weaponController.Resstart();
        SetActiveArea(index);
    }
    public void RePlayArea()
    {
        GridManager.instance.GetCurrentGrid().Restart();
        index--;
        SetActiveArea(index);
        weaponController.Resstart();
        timer.Restart();
    }
    public virtual void Update()
    {

    }
}
