using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    [Header("Character Data")]
    [SerializeField] private List<WeaponProfile> weapons;
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private WeaponProfile currentWeaponProfile;

    [Space]
    [Header("UI Elements")]
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Button switchLeftButton;
    [SerializeField] private Button switchRightButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Image lockImage;
    [SerializeField] private Text coinRequiredText;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;


    [Space]
    [Header("UI Atribute")]
    [SerializeField] private Text weaponNameTxt;
    [SerializeField] private Text weaponLevelTxt;
    [SerializeField] private Text ammoTxt;
    [SerializeField] private Text descriptionTxt;


    [Serializable]
    public class WeaponProfile
    {
        public GenericWeapon weaponData;
        public Sprite weaponAvt;

    }
    private void Start()
    {
        if (weapons.Count > 0)
        {
            currentWeaponProfile = weapons[currentIndex];
            UpdateCharacter();
            switchLeftButton.onClick.AddListener(SwitchWeaponLeft);
            switchRightButton.onClick.AddListener(SwitchWeaponRight);
            upgradeButton.onClick.AddListener(UpgradeWeapon);
        }
        else
        {
            Debug.LogError("Không có weapon trong danh sách.");
        }
    }

    private void SwitchWeaponLeft()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = weapons.Count - 1;
        }
        currentWeaponProfile = weapons[currentIndex];
        UpdateCharacter();
    }

    private void SwitchWeaponRight()
    {
        currentIndex++;
        if (currentIndex >= weapons.Count)
        {
            currentIndex = 0;
        }
        currentWeaponProfile = weapons[currentIndex];
        UpdateCharacter();
    }

    [Obsolete]
    private void UpgradeWeapon()
    {
        int currentLevel = currentWeaponProfile.weaponData.level;
        int requiredCoin = 50 * currentLevel;
        float upgradeSuccessRate;
        switch (currentLevel)
        {
            case 1:
                upgradeSuccessRate = 80;
                break;
            case 2:
                upgradeSuccessRate = 60;
                break;
            case 3:
                upgradeSuccessRate = 40;
                break;
            case 4:
                upgradeSuccessRate = 20;
                break;
            case 5:
                upgradeSuccessRate = 10;
                break;
            default:
                upgradeSuccessRate = 5;
                break;
        }
        float randomUpgradeSuccessRate = UnityEngine.Random.RandomRange(0, 100);
        if (currentLevel < 7 &&
            CurrencyManager.instance.GetCurrencyQuantity(CurrencyManager.CurrencyType.Coin) >= requiredCoin )
        {
            CurrencyManager.instance.RemoveItem(CurrencyManager.CurrencyType.Coin, requiredCoin);
            if (randomUpgradeSuccessRate <= upgradeSuccessRate)
            {
                currentWeaponProfile.weaponData.level++;
                int newLevel = currentWeaponProfile.weaponData.level;

                currentWeaponProfile.weaponData.UpgradeWeapon();
                string tip = "Weapon upgraded successfully to level " + currentWeaponProfile.weaponData.level;
                GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
                tipObjectIns.GetComponentInChildren<Text>().text = tip.ToUpper();
                Destroy(tipObjectIns, 1f);

                Debug.Log("Weapon upgraded successfully to level " + currentWeaponProfile.weaponData.level);
            }
            else
            {
                string tip = "Weapon upgrade failded";
                GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
                tipObjectIns.GetComponentInChildren<Text>().text = tip.ToUpper();
                Destroy(tipObjectIns, 1f);

                Debug.Log("Weapon upgrade failded");
            }

            UpdateCharacter();
        }
        else
        {
            string tip = "Not enough resources or already at maximum level to upgrade weapon!";
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = tip.ToUpper();
            Destroy(tipObjectIns, 1f);
            Debug.Log("Not enough resources or already at maximum level to upgrade weapon!");
        }
    }


    private void UpdateCharacter()
    {

        weaponIcon.sprite = currentWeaponProfile.weaponAvt;
        if (!currentWeaponProfile.weaponData.isUnlock)
        {
            lockImage.enabled = true;
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            lockImage.enabled = false;
            int currentLevel = currentWeaponProfile.weaponData.level;
            float upgradeSuccessRate;
            switch (currentLevel)
            {
                case 1:
                    upgradeSuccessRate = 80;
                    break;
                case 2:
                    upgradeSuccessRate = 60;
                    break;
                case 3:
                    upgradeSuccessRate = 40;
                    break;
                case 4:
                    upgradeSuccessRate = 20;
                    break;
                case 5:
                    upgradeSuccessRate = 10;
                    break;
                default:
                    upgradeSuccessRate = 5;
                    break;
            }
            if (currentLevel < 7)
            {
                upgradeButton.GetComponentInChildren<Text>().text = "UPGRADE(Success Rate:" + upgradeSuccessRate + "%)"; ;
                int requiredCoin = 50 * currentLevel;
                int requiredGem = 10 * currentLevel;
                coinRequiredText.text = requiredCoin.ToString();
                coinRequiredText.gameObject.SetActive(true);
            }
            else
            {
                upgradeButton.GetComponentInChildren<Text>().text = "MAX";
                coinRequiredText.gameObject.SetActive(false);
 
            }
            upgradeButton.gameObject.SetActive(true);
        }
        weaponNameTxt.text = currentWeaponProfile.weaponData.name;
        weaponLevelTxt.text = "Lv." + currentWeaponProfile.weaponData.level.ToString();
        weaponNameTxt.text = currentWeaponProfile.weaponData.name;
        ammoTxt.text = currentWeaponProfile.weaponData.IsInfiniteAmmo ? "Infinite" : currentWeaponProfile.weaponData.AmmoCount.ToString(); 
        weaponIcon.sprite = currentWeaponProfile.weaponAvt;
        descriptionTxt.text = "\nDamage Rate: " + 
            currentWeaponProfile.weaponData.DamageRate * 100 + "%" + "\nFire Rate: " + currentWeaponProfile.weaponData.FireRate+"s" +
            "\nType: " + currentWeaponProfile.weaponData.weaponType + "\n";

    }
}
