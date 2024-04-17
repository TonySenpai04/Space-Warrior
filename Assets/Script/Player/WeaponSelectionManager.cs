using System;
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
                GenericWeapon genericWeapon = weaponSlots[slot].Weapons[index];
                WeaponButtonSelect weaponButtonSelect = null;
                for (int i = 0; i < weaponButtonSelects.Count; i++)
                {
                    if (weaponButtonSelects[i].weapon == genericWeapon)
                    {
                        weaponButtonSelect = weaponButtonSelects[i];
                    }
                }
                int emptyIndex = -1;
                for (int i = 0; i < weaponSelections.Count; i++)
                {
                    if (weaponSelections[i].weaponSelectedGenericWeapon == null)
                    {
                        emptyIndex = i;
                        break;
                    }
                }
                if (genericWeapon != null)
                {
                    for (int i = 0; i < weaponSelections.Count; i++)
                    {
                        if (weaponSelections[i].weaponSelectedGenericWeapon != genericWeapon)
                        {
                            weaponSelections[emptyIndex].SetWeapon(genericWeapon, slot, index, weaponButtonSelect.weaponImage.sprite);
                            // weaponSelections[weaponsIndex.IndexOf(weaponIndex)].SetWeapon(genericWeapon,slot,index, weaponButtonSelect.weaponImage.sprite);
                        }
                    }
                }
            }
            Debug.Log(weaponsIndex.Count);
            
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
            for (int i = 0; i < weaponSelections.Count; i++)
            {
               
               if( weaponSelections[i].slot == slot && weaponSelections[i].weaponIndex == index)
                {
                    weaponSelections[i].slot = -1;
                    weaponSelections[i].weaponIndex = -1;
                    weaponSelections[i].weaponSelectedGenericWeapon = null;
                    break;
               }

            }
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
            for (int i = 0; i < swapSelected.Length; i++)
            {
                if (weaponSelections[i].weaponSelectedGenericWeapon != null)
                {
                    swapSelected[i].SetSlot(weaponSelections[i].slot, weaponSelections[i].weaponIndex);
                    swapSelected[i].SetWeaponSelected(weaponSelections[i]);
                }
                else
                {
                    swapSelected[i].SetSlot(-1, -1);
                }
            }
            weaponController.SetWeapon(weaponSelections[0].slot, weaponSelections[0].weaponIndex);
        }
        weaponController.ActivateWeapon(weaponSelections[0].slot, weaponSelections[0].weaponIndex);
    }
}
