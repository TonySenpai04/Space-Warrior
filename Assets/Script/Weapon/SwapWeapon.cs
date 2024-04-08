using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapWeapon : MonoBehaviour
{
    [Header("Generic")]
    [SerializeField] private int slotIndex;
    [SerializeField] private int weaponIndex;
    [SerializeField] private Button button;
    [SerializeField] private WeaponControllerBase weaponController;
    [Header("UI")]
    [SerializeField] private Text currentAmmoTxt;
    [SerializeField] private Text ammoCountTxt;
    [SerializeField] private Sprite nomarlWeapon;
    [SerializeField] private Sprite selectedWeapon;
    [SerializeField] private Image weaponImage;
  
  
    private void Start()
    {
        weaponController=FindAnyObjectByType<WeaponControllerBase>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ActivateWeapon);
        if (GetWeapon() != null)
        {
            
            weaponImage.sprite = weaponController.GetWeapon(slotIndex, weaponIndex).weaponSprite.sprite;
            if (!GetWeapon().IsInfiniteAmmo) {
                ammoCountTxt.text = " /" + GetWeapon().AmmoCount.ToString();
                currentAmmoTxt.text = GetWeapon().AmmoCount.ToString();
               
            }
            else {
                currentAmmoTxt.text = "";
                ammoCountTxt.text = "";
            }
        }
    }
    private void FixedUpdate()
    {
        if (GetWeapon() != null)
        {

            if (!GetWeapon().IsInfiniteAmmo)
            {
                currentAmmoTxt.text = GetWeapon().CurrentAmmo.ToString();
                ammoCountTxt.text = " /"+GetWeapon().AmmoCount.ToString();
            }
            else
            {
                currentAmmoTxt.text = "";
                ammoCountTxt.text = "";
            }
 
            if(GetWeapon()!= weaponController.GetCurrentWeapon()) {
                button.image.sprite = nomarlWeapon;
            }
            else
            {
                button.image.sprite = selectedWeapon;
            }
        }
    }

    private void ActivateWeapon()
    {
        if (GetWeapon() != null)
        {
            //GenericWeapon weapon = WeaponController.instance.GetCurrentWeapon();
            //int newSlotIndex = weaponController.GetWeaponIndex(weapon).Item1;
            //int newWeaponIndex = weaponController.GetWeaponIndex(weapon).Item2;
            //Debug.Log(newSlotIndex + "-" + newWeaponIndex);

            weaponController.ActivateWeapon(slotIndex, weaponIndex);
   
            //slotIndex = newSlotIndex;
            //weaponIndex = newWeaponIndex;
            // weaponImage.sprite = weaponController.GetWeapon(slotIndex, weaponIndex).weaponSprite.sprite;
        }
         
    }
    public GenericWeapon GetWeapon()
    {
        return weaponController.GetWeapon(slotIndex, weaponIndex);
    }
}
