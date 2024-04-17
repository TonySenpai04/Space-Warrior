using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPlanet : MonoBehaviour
{
    [SerializeField] private GameObject areaSelection;
    [SerializeField] private bool isUnlock;
    [SerializeField] private GameObject blackMask;
    [SerializeField] private CustomAreaController customAreaController;
    [SerializeField] private Button btn;
    private void Start()
    {
        btn=GetComponent<Button>();
        btn.onClick.AddListener(SelectPlanet);
        if (isUnlock)
            blackMask.gameObject.SetActive(false);
        else blackMask.gameObject.SetActive(true);



    }
    public void SelectPlanet()
    {
        if (isUnlock)
        {
            areaSelection.gameObject.SetActive(true);
            customAreaController.gameObject.SetActive(true);
        }
    }

}
