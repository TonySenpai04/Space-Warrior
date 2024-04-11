using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomArea  : MonoBehaviour
{
    [SerializeField] private bool isUnlock;
    [SerializeField] public int index;
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

        if (isUnlock)
        {
            btnLock.gameObject.SetActive(false);
            Toggle[] toggles = GetComponentsInChildren<Toggle>();
            foreach(Toggle toggle in toggles)
            {
                starList.Add(toggle);
            }
        }
    }
    public void Unlock()
    {
        isUnlock = true;
    }
    public void Active()
    {
        if (isUnlock)
        {
            CustomAreaController controller = GetComponentInParent<CustomAreaController>();
            loading.gameObject.SetActive(true);
            mapSelection.SetActive(false);
            levelSelection.SetActive(false);
            controller.SetArea(index);
        }

    }
}
