using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponButtonSelect : MonoBehaviour
{
    [SerializeField] private int slot;
    [SerializeField] private int weaponIndex;
    [SerializeField] public Image weaponImage;
    [SerializeField] public GenericWeapon weapon;
    [SerializeField] private Text weaponName;
    [SerializeField] private Button weaponButton;



    void Start()
    {
        InitializeComponents();
        SetupButtonListener();
        DisableRaycastTarget();
    }

    void InitializeComponents()
    {
        weaponButton = GetComponent<Button>();
      
    }

    void SetupButtonListener()
    {
        weaponButton.onClick.AddListener(SelectedWeapon);
    }

    void DisableRaycastTarget()
    {
        weaponImage.raycastTarget = false;
    }

    private void SelectedWeapon()
    {
        GetComponentInParent<WeaponSelectionManager>().AddWeapon(slot, weaponIndex);
    }
    public void SetWeapon(int slot, int weaponIndex,GenericWeapon weapon)
    {
        this.slot = slot;
        this.weaponIndex = weaponIndex;
        this.weapon = weapon;
        this.weaponName.text = weapon.name;
        this.weaponImage.sprite = weapon.weaponSprite.sprite;
    }

}
