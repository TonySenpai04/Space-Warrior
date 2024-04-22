using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public Image weaponSelectedImage;
    public GenericWeapon weaponSelectedGenericWeapon;
    public int slot;
    public int weaponIndex;
    public Button removeWeaponBtn;
    public WeaponSelectionManager weaponSelectionManager;
    private void Start()
    {
        CheckWeaponSelection();
    }
    private void CheckWeaponSelection()
    {
        if (weaponSelectedGenericWeapon == null)
        {
            DisableWeaponImage();
            removeWeaponBtn.gameObject.SetActive(false);
            removeWeaponBtn.onClick.AddListener(RemoveWeapon);
        }
    }
    private void DisableWeaponImage()
    {
        weaponSelectedImage.enabled = false;
    }
    public void SetWeapon(GenericWeapon genericWeapon,int slot,int index,Sprite weaponSprite)
    {
        weaponSelectedImage.enabled = true;
        weaponSelectedGenericWeapon =genericWeapon;
        weaponSelectedImage.sprite = weaponSprite;
        this.slot = slot;   
        this.weaponIndex = index;
        removeWeaponBtn.gameObject.SetActive(true);

    }
    public void RemoveWeapon()
    {
      
        weaponSelectionManager.RemoveWeapon(this.slot, this.weaponIndex);
        removeWeaponBtn.gameObject.SetActive(false);
        DisableWeaponImage();
        weaponSelectedGenericWeapon = null;
    }
}
