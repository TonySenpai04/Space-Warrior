using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemQuantityUI : MonoBehaviour
{
    [Serializable]
    public struct UIItem {

        public ItemManager.ItemType itemType;

        public TextMeshProUGUI quantityText;
    }

    [SerializeField] private UIItem[] items;    
    private void Start()
    {
    }

    private void UpdateQuantity()
    {
        for (int i = 0; i < items.Length; i++)
        {
            ItemManager.ItemType itemType = items[i].itemType;
            ItemManager.Item itemInInventory = ItemManager.instance.Inventory.Find(item => item.type == itemType);
            items[i].quantityText.text = itemInInventory.quantity.ToString();

        }

    }
    private void FixedUpdate()
    {
        UpdateQuantity();
    }
}
