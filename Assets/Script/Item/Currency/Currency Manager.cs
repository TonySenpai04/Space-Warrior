using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public enum CurrencyType
    {
        Coin,
        Soul,
        Gem
    }

    [System.Serializable]
    public struct Currency 
    {
        public CurrencyType type;
        public int quantity;
    }

   [SerializeField] private List<Currency > inventory ;

    public List<Currency > Inventory { get => inventory;  }

    void Start()
    {
        instance = this;

    }
    
    public void AddItem(CurrencyType type, int quantity)
    {
        int index = Inventory.FindIndex(item => item.type == type);
        if (index != -1)
        {
            Currency  existingItem = Inventory[index];
            existingItem.quantity += quantity;
            Inventory[index] = existingItem;
        }
        else
        {
            Currency  newItem = new Currency  { type = type, quantity = quantity };
            Inventory.Add(newItem);
        }
    }

    public void RemoveItem(CurrencyType type, int quantity)
    {
        Currency  existingItem = Inventory.Find(item => item.type == type);

        if (existingItem.type == type)
        {
            existingItem.quantity -= quantity;
            if (existingItem.quantity <= 0)
            {
                Inventory.Remove(existingItem);
            }
        }
    }

}
