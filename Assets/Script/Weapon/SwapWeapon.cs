using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapWeapon : MonoBehaviour
{
    [Header("Generic")]
    [SerializeField] private int slotIndex=-1;
    [SerializeField] private int weaponIndex=-1;
    [SerializeField] private Button button;
    [SerializeField] private WeaponControllerBase weaponController;
    [SerializeField] WeaponSelection weaponSelection;
    [Header("UI")]
    [SerializeField] private Text currentAmmoTxt;
    [SerializeField] private Text ammoCountTxt;
    [SerializeField] private Sprite nomarlWeapon;
    [SerializeField] private Sprite selectedWeapon;
    [SerializeField] private Image weaponImage;


    private void Start()
    {
        InitializeComponents();
        SetupButtonListener();
        SetupWeaponInfo();
    }

    private void InitializeComponents()
    {
        weaponController = FindAnyObjectByType<WeaponControllerBase>();
        button = GetComponent<Button>();
    }

    private void SetupButtonListener()
    {
        button.onClick.AddListener(ActivateWeapon);
    }

    private void SetupWeaponInfo()
    {
        GenericWeapon weapon = GetWeapon();
        if (weapon != null)
        {
            UpdateWeaponImage();
            UpdateAmmoInfo(weapon);
        }
        else
        {
            weaponImage.enabled=false;
            UpdateAmmoInfo(weapon);
        }
    }


    private void UpdateWeaponImage()
    {
        if(weaponSelection!=null)
        weaponImage.sprite = weaponSelection.weaponSelectedImage.sprite;
    }

    private void UpdateAmmoInfo(GenericWeapon weapon)
    {
        if (weapon != null)
        {
            if (!weapon.IsInfiniteAmmo)
            {
                ammoCountTxt.text = " /" + weapon.AmmoCount.ToString();
                currentAmmoTxt.text = weapon.AmmoCount.ToString();
            }
            else
            {
                currentAmmoTxt.text = "";
                ammoCountTxt.text = "";
            }
        }
        else
        {
            currentAmmoTxt.text = "";
            ammoCountTxt.text = "";
        }

    }
    public void SetWeaponSelected(WeaponSelection weaponSelection)
    {
        this.weaponSelection = weaponSelection;
    }
    public void SetSlot(int slotIndex, int weaponIndex)
    {
        this.slotIndex= slotIndex;
        this.weaponIndex= weaponIndex;
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

            weaponController.ActivateWeapon(slotIndex, weaponIndex);
        }
         
    }
    public GenericWeapon GetWeapon()
    {
        if(slotIndex >=0 && weaponIndex>=0)
        return weaponController.GetWeapon(slotIndex, weaponIndex);
        else return null;
    }
}
