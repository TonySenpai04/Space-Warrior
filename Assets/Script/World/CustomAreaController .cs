using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomAreaController : MonoBehaviour
{
    [SerializeField] private List<CustomArea> areaList;
    [SerializeField] private Planet planet;
    [SerializeField] private GameObject map;
    [SerializeField] private int totalStar;
    [SerializeField] private int currentStar;
    [SerializeField] private Text currentStarTxt;
    [SerializeField] private Text totalStarTxt;
    void Start()
    {

        GetArea();
        UpdateCurentStar();
        UpdateTotalStar();
        UpdateStarTxt();
    }


    //void FixedUpdate()
    //{
    //    SetCurentStar();
    //    SetTotalStar();
    //    SetStarTxt();
    //}
    public void UpdateStar()
    {
        UpdateCurentStar();
        UpdateTotalStar();
        UpdateStarTxt();
    }
    public void UpdateStarTxt()
    {
        currentStarTxt.text = currentStar.ToString();
        totalStarTxt.text = "/" + totalStar.ToString();
    }
    public void GetArea()
    {
        CustomArea[] list = GetComponentsInChildren<CustomArea>();
        for (int i = 0; i < list.Length; i++)
        {
            areaList.Add(list[i]);
            list[i].SetIndex(i);
        }
       

    }
    public void UpdateCurentStar()
    {
       
        for (int i = 0; i < areaList.Count; i++)
        {
            if (areaList[i].GetUnlock())
            {
                currentStar += areaList[i].GetStar();
            }
        }
    }
    public void UpdateTotalStar()
    {
        totalStar = areaList.Count * 3;
    }
    public void SetArea(int index)
    {
        map.SetActive(true);
        planet.gameObject.SetActive(true);
        List<Area> area = planet.GetAreas();
        for (int i = 0; i < areaList.Count; i++)
        {
            areaList[i].SetArea(area[i]);
        }
        planet.SetActiveArea(index);
    }
}

