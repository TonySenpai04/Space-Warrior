﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionManager : MonoBehaviour
{
    [SerializeField] private List<WeaponButtonSelect> weaponButtonSelects;
    [SerializeField] private List<WeaponControllerBase.WeaponSlot> weaponSlots;
    [SerializeField] private WeaponControllerBase weaponController;
    [SerializeField] private List<Tuple<int,int>> weaponsIndex=new(3);
    [SerializeField] private SwapWeapon[] swapSelected =new SwapWeapon[3];
    [SerializeField] private List<WeaponSelection> weaponSelections = new(3);
    [SerializeField] private GameObject mapSelection;
    [SerializeField] private Button nextPageBtn;
    [SerializeField] private GameObject weaponSelection;
    void Start()
    {
        nextPageBtn.onClick.AddListener(NextPage);
    }
    private void Reset()
    {
        weaponController = FindAnyObjectByType<WeaponControllerBase>();
        weaponSlots = weaponController.GetSlotListCopy();
        WeaponButtonSelect[] weaponButtonSelects=GetComponentsInChildren<WeaponButtonSelect>();
        foreach(WeaponButtonSelect weaponButton in weaponButtonSelects) {
            this.weaponButtonSelects.Add(weaponButton);
        }
        
        AssignWeaponButtonSelectsToSlots();
    }


    public void AssignWeaponButtonSelectsToSlots()
    {
        int weaponIndex = 0;

        foreach (WeaponControllerBase.WeaponSlot slot in weaponSlots)
        {
            foreach (GenericWeapon weapon in slot.Weapons)
            {
                if (weaponIndex < weaponButtonSelects.Count)
                {
                    WeaponButtonSelect buttonSelect = weaponButtonSelects[weaponIndex];
                    buttonSelect.SetWeapon(weaponSlots.IndexOf(slot), slot.Weapons.IndexOf(weapon), weapon);
                    //buttonSelect.slot = weaponSlots.IndexOf(slot);
                    //buttonSelect.weaponIndex = slot.Weapons.IndexOf(weapon);
                    //buttonSelect.weapon = weapon;
                    //buttonSelect.weaponName.text = weapon.name;
                    //buttonSelect.weaponImage.sprite = weapon.weaponSprite.sprite;
                }

                weaponIndex++;
            }
        }
    }
    public void AddWeapon(int slot, int index)
    {
        Tuple<int, int> weaponIndex = new Tuple<int, int>(slot, index);

        bool weaponExists = false;
        foreach (var existingWeaponIndex in weaponsIndex)
        {
            if (existingWeaponIndex.Item1 == slot && existingWeaponIndex.Item2 == index)
            {
                weaponExists = true;
                break;
            }
        }

        if (!weaponExists)
        {
            if (weaponsIndex.Count < 3)
            {
                weaponsIndex.Add(weaponIndex);
            }

            GenericWeapon genericWeapon = weaponSlots[slot].Weapons[index];
            WeaponButtonSelect weaponButtonSelect=new WeaponButtonSelect();
            for(int i=0;i< weaponButtonSelects.Count; i++)
            {
                if (weaponButtonSelects[i].weapon== genericWeapon)
                {
                    weaponButtonSelect = weaponButtonSelects[i];
                }
            }
            if (genericWeapon != null)
            {
                for (int i = 0; i < weaponSelections.Count; i++)
                {
                    if (weaponSelections[i].weaponSelectedGenericWeapon != genericWeapon)
                    {
                        weaponSelections[weaponsIndex.IndexOf(weaponIndex)].SetWeapon(genericWeapon,slot,index, weaponButtonSelect.weaponImage.sprite);
                    }
                }
            }
        }
        else
        {
            Debug.Log("This weapon already exists in the selection.");
        }
    }
    public void RemoveWeapon(int slot, int index)
    {
        Tuple<int, int> weaponIndexToRemove = new Tuple<int, int>(slot, index);

        if (weaponsIndex.Contains(weaponIndexToRemove))
        {
            weaponSelections[weaponsIndex.IndexOf(weaponIndexToRemove)].RemoteWeapon();
            weaponsIndex.Remove(weaponIndexToRemove);   
            Debug.Log("Weapon removed successfully.");
        }
        else
        {
            Debug.Log("Weapon not found in the selection.");
        }
    }

    public void NextPage()
    {
        if (weaponsIndex.Count >= 1 )
        {
            mapSelection.gameObject.SetActive(true);
            weaponSelection.gameObject.SetActive(false);
            for (int i = 0; i < weaponsIndex.Count; i++)
            {
                swapSelected[i].SetSlot(weaponsIndex[i].Item1, weaponsIndex[i].Item2);
                swapSelected[i].SetWeaponSelected(weaponSelections[i]);
            }
            weaponController.SetWeapon(weaponsIndex[0].Item1, weaponsIndex[0].Item2);
        }
    }
}
