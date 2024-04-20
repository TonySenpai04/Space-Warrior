using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShop : ShopItem
{
    [SerializeField] private ChacracterData chacracterData;
    public override void Awake()
    {
        this.itemName = chacracterData.characterName;
    }
    public override void Buy()
    {
        CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == priceType);
        if (currency.type == priceType && currency.quantity >= price)
        {
            currency.quantity -= price;
            isBuy = true;
            chacracterData.isUnlock = true;
            Debug.Log(chacracterData.isUnlock);
        }
    }
    public override int GetPrice()
    {
        return this.price;
    }
    public override string GetInfo()
    {
        return "";
    }
}
