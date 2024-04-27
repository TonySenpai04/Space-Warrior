using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ShopItem,IWeaponItem
{
    
    [SerializeField] private GenericWeapon weapon;
   
    public override void Awake()
    {
        this.itemName=weapon.name;
    }
    public override void Buy()
    {
        CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == priceType);
        if (currency.type == priceType && currency.quantity >= price)
        {
            CurrencyManager.instance.RemoveItem(priceType, price);
            isBuy = true;
            weapon.isUnlock = true;
            Debug.Log(weapon.isUnlock);
        }
    }
    public override int  GetPrice()
    {
        return this.price;
    }
    public override string GetInfo()
    {

        string info = "\nDamage Rate: " + weapon.DamageRate*100+"%" + "\nFire Rate: " + weapon.FireRate+"s"+
            "\nType: " + weapon.weaponType + "\n";
        return info;
    }

    public string GetAmmo()
    {
        return weapon.IsInfiniteAmmo ? "Infinite" : weapon.AmmoCount.ToString();
    }

    public string GetWeaponName()
    {
        return weapon.name;
    }

    public GenericWeapon GetWeapon()
    {
        return weapon;
    }
}
