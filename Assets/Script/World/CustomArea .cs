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

    [Header("UI")]
    [SerializeField] private Button button;
    [SerializeField] private Button btnLock; 
    [SerializeField] private List<Toggle> starList;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Active);

        if (area.GetUnlock())
        {
            btnLock.gameObject.SetActive(false);
            Toggle[] toggles = GetComponentsInChildren<Toggle>();
            foreach(Toggle toggle in toggles)
            {
                starList.Add(toggle);
            }
        }
    }
    private void FixedUpdate()
    {
        if (area.GetUnlock())
        {
            btnLock.gameObject.SetActive(false);
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

    public void Active()
    {
        if (area.GetUnlock())
        {
            CustomAreaController controller = GetComponentInParent<CustomAreaController>();
            loading.gameObject.SetActive(true);
            mapSelection.SetActive(false);
            levelSelection.SetActive(false);
            controller.SetArea(index);
        }

    }
}
