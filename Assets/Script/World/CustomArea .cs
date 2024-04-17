using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomArea  : MonoBehaviour
{
    [SerializeField] private Area area;
    [SerializeField] private int index;
    [SerializeField] private GameObject mapSelection;
    [SerializeField] private GameObject levelSelection;
    [SerializeField] private GameObject loading;
    [SerializeField]private GameObject home;

    [Header("UI")]
    [SerializeField] private Button button;
    [SerializeField] private Button btnLock; 
    [SerializeField] private List<Toggle> starList;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Active);
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            starList.Add(toggle);
        }
        if (area.GetUnlock())
        {
            btnLock.gameObject.SetActive(false);
            
        }
    }
    private void FixedUpdate()
    {
        if (area.GetUnlock())
        {
            btnLock.gameObject.SetActive(false);
            SetStars();

        }
    }
    public void SetStars()
    {
        for(int i = 0; i < area.GetStar(); i++)
        {
            this.starList[i].isOn = true;
        }
    }
    public void SetArea(Area area)
    {
        this.area = area;
    }
    public void SetIndex(int index)
    {
        this.index= index;
    }
    public int GetStar()
    {
        return area.GetStar();
    }
    public void Active()
    {
        if (area.GetUnlock())
        {
            CustomAreaController controller = GetComponentInParent<CustomAreaController>();
            loading.gameObject.SetActive(true);
            mapSelection.SetActive(false);
            levelSelection.SetActive(false);
            controller.SetArea(index);
            home.gameObject.SetActive(false);
        }

    }
    public bool GetUnlock()
    {
        return area.GetUnlock();
    }
}
