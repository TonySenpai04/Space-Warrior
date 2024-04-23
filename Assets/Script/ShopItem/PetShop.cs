using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShop : ShopItem,IPetShop
{
    [SerializeField] private Pet pet;

    public override void Awake()
    {
        this.itemName = pet.petName;
    }
    public override void Buy()
    {
        CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == priceType);
        if (currency.type == priceType && currency.quantity >= price)
        {
            CurrencyManager.instance.RemoveItem(priceType, price);
            isBuy = true;
            pet.isUnlock = true;
        }
    }
    public override int GetPrice()
    {
        return this.price;
    }
    public override string GetInfo()
    {

        string info = pet.GetSkillDescription();
        return info;
    }

    public Pet GetPet()
    {
        return this.pet;
    }

    public string GetPetName()
    {
        return this.pet.petName;
    }
}
