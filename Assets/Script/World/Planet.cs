using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public abstract class Planet : MonoBehaviour
{
    [SerializeField] protected List<Area> areas;
    [SerializeField] protected int index = 0;
    [SerializeField] protected bool isFinish;
    [SerializeField] protected  Timer timer;
    [SerializeField] protected WeaponControllerBase weaponController;
    [SerializeField] protected CharacterStats characterStats;
    [SerializeField] protected CustomAreaController areaController;
    [SerializeField] protected string planetName;
    public virtual void Awake()
    {
        if (areas == null)
        {
            InitializeAreas();
        }
        LoadAreaStates();
    }
    public virtual void Start()
    {
        //if(areas == null)
        //    InitializeAreas();
        
    }
    
    public virtual void SaveAreaStates()
    {
        for (int i = 0; i < areas.Count; i++)
        {
            
            string keyPrefix =planetName+"-"+"Area_" + i + "_";
            PlayerPrefs.SetInt(keyPrefix + "Unlocked", areas[i].isUnlocked ? 1 : 0);
            PlayerPrefs.SetInt(keyPrefix + "Completed", areas[i].isCompleted ? 1 : 0);
            PlayerPrefs.SetInt(keyPrefix + "StarsEarned", areas[i].stars);
        }
        PlayerPrefs.SetInt("isSave"+ planetName, 1);
        PlayerPrefs.Save();
    }
    public virtual void OnApplicationQuit()
    {
        SaveAreaStates();
    }
    public virtual void LoadAreaStates()
    {
        if (PlayerPrefs.GetInt("isSave" + planetName, 0) == 1)
        {
            for (int i = 0; i < areas.Count; i++)
            {

                string keyPrefix = planetName + "-" + "Area_" + i + "_";
                bool isUnlocked = PlayerPrefs.GetInt(keyPrefix + "Unlocked", 0) == 1;
                bool isCompleted = PlayerPrefs.GetInt(keyPrefix + "Completed", 0) == 1;
                int starsEarned = PlayerPrefs.GetInt(keyPrefix + "StarsEarned", 0);
                areas[i].isUnlocked = isUnlocked;
                areas[i].isCompleted = isCompleted;
                areas[i].stars = starsEarned;

            }
        }
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
            characterStats.Restart();
            if (index < areas.Count-1)
            {
                index++;
                areas[index].Unlock();
            }
            areaController.UpdateStar();
        }
    }
    public void NextArea()
    {
        GridManager.instance.GetCurrentGrid().Restart();
        timer.Restart();
        weaponController.Resstart();
        SetActiveArea(index);
        SkillManager.instance.Restart();
    }
    public void RePlayArea()
    {
        GridManager.instance.GetCurrentGrid().Restart();
        index--;
        SetActiveArea(index);
        weaponController.Resstart();
        timer.Restart();
        SkillManager.instance.Restart();
    }
    public virtual void Update()
    {
        for (int i = 0; i < areas.Count; i++)
        {

            if (areas[i].isCompleted && i < areas.Count - 1)
            {
                areas[++i].Unlock();
                Debug.Log("Unlocking next area: " + (i ));
                break;
            }
        }
    }
}
