using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;



public class WeaponShopItemUI : MonoBehaviour
{
    [SerializeField] private Text weaponNameTxt;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private ShopItem weaponItem;
    [SerializeField] private Text descriptionTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text AmmoTxt;
    [SerializeField] private Button buyBtn;
    [SerializeField] private Sprite alreadyOwnedSprite;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;
    public void Start()
    {
        weaponItem = GetComponent<ShopItem>();
        SetWeaponInfo(weaponItem);
    }

    private void SetWeaponInfo(ShopItem item)
    {
        IWeaponItem weapon = (IWeaponItem)item;
        buyBtn=GetComponentInChildren<Button>();
        priceTxt = buyBtn.GetComponentInChildren<Text>();
        if (weapon.GetWeapon().isUnlock)
        {
           priceTxt.text = "Already Owned";
            foreach (RectTransform child in buyBtn.GetComponent<RectTransform>())
            {
                Image image = child.GetComponent<Image>();
                if (image != null && image != buyBtn.GetComponent<Image>())
                {
                    image.enabled = false;
                }
            }
        }
        else
        {
            buyBtn.onClick.AddListener(Buy);
            priceTxt.text = item.GetPrice().ToString();
        }
       
        weaponNameTxt.text = weapon.GetWeaponName();
        AmmoTxt.text = weapon.GetAmmo();
        weaponIcon.sprite = item.itemSprite;
        descriptionTxt.text = item.GetInfo();
    }
    public void Buy()
    {
        
            weaponItem.Buy();
        if (weaponItem.isBuy)
        {
            IWeaponItem weapon = (IWeaponItem)weaponItem;
            buyBtn.GetComponentInChildren<Text>().text = "Already Owned";
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "YOU GET " + weapon.GetWeaponName().ToUpper();
            Destroy(tipObjectIns, 1f);
            foreach (RectTransform child in buyBtn.GetComponent<RectTransform>())
            {
                Image image = child.GetComponent<Image>();
                if (image != null && image != buyBtn.GetComponent<Image>())
                {
                    image.enabled = false;
                }
            }
            buyBtn.onClick.RemoveListener(Buy);
            buyBtn.GetComponent<Image>().sprite = alreadyOwnedSprite;
        }
        else
        {
            CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == weaponItem.priceType);
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "YOU STILL LACK " + (int)(weaponItem.price - currency.quantity) + " " +
                weaponItem.priceType.ToString().ToUpper() + " TO BUY";
            Destroy(tipObjectIns, 1f);
        }


    }

}

