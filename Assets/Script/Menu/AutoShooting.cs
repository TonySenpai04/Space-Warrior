using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Button autoBnt;
    [SerializeField] private WeaponControllerBase weaponController;
    [SerializeField] private Sprite normalAuto;
    [SerializeField] private Sprite activeAuto;

    private void Start()
    {
       autoBnt=GetComponent<Button>();
       autoBnt.GetComponent<Image>().sprite = normalAuto;
       autoBnt.onClick.AddListener(AutoShoot);
    }
    public void AutoShoot()
    {
        weaponController.AutoShoting();
       if(!weaponController.GetAutoState())
        {
            autoBnt.GetComponent<Image>().sprite = normalAuto;

        }
        else
        {
            autoBnt.GetComponent<Image>().sprite = activeAuto;
        }
    }
}
