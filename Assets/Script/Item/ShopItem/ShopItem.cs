using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public CurrencyManager.CurrencyType priceType;
    public int price;
    public bool isBuy;
    public virtual void Start()
    {

    }
    public virtual void Buy()
    {

    }
    public virtual int GetPrice()
    {
        return this.price;
    }
    public virtual string GetInfo()
    {
        return "";
    }
}
