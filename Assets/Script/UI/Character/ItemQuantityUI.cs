using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuantityUI : MonoBehaviour
{
    [Serializable]
    public struct UIItem {

        public CurrencyManager.CurrencyType itemType;

        public Text quantityText;
    }

    [SerializeField] private UIItem[] items;    
    private void Start()
    {
    }

    private void UpdateQuantity()
    {
        for (int i = 0; i < items.Length; i++)
        {
            CurrencyManager.CurrencyType itemType = items[i].itemType;
            CurrencyManager.Currency  itemInInventory = CurrencyManager.instance.Inventory.Find(item => item.type == itemType);
            items[i].quantityText.text = itemInInventory.quantity.ToString();

        }

    }
    private void FixedUpdate()
    {
        UpdateQuantity();
    }
}
