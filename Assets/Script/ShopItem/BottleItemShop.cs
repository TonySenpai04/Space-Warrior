using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleItemShop : ShopItem
{
    [SerializeField] private Bottle bottle;
    [SerializeField] private string description;

    public override void Awake()
    {
        this.itemName = bottle.bottleName;
    }
    public override void Buy()
    {
        CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == priceType);
        if (currency.type == priceType && currency.quantity >= price)
        {
            CurrencyManager.instance.RemoveItem(priceType, price);
            bottle.count++;

        }
    }
    public override int GetPrice()
    {
        return this.price;
    }
    public override string GetInfo()
    {
        return description;
    }

}
