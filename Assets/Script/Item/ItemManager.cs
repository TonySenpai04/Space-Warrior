using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public enum ItemType
    {
        Gold,
        Soul,
        Diamond
    }

    [System.Serializable]
    public struct Item
    {
        public ItemType type;
        public int quantity;
    }

   [SerializeField] private List<Item> inventory ;

    public List<Item> Inventory { get => inventory;  }

    void Start()
    {
        instance = this;

    }

    public void AddItem(ItemType type, int quantity)
    {
        int index = Inventory.FindIndex(item => item.type == type);
        if (index != -1)
        {
            Item existingItem = Inventory[index];
            existingItem.quantity += quantity;
            Inventory[index] = existingItem;
        }
        else
        {
            Item newItem = new Item { type = type, quantity = quantity };
            Inventory.Add(newItem);
        }
    }

    public void RemoveItem(ItemType type, int quantity)
    {
        Item existingItem = Inventory.Find(item => item.type == type);

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
