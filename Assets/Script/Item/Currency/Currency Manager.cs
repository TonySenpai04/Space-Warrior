using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TextCore.Text;

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
    private void Awake()
    {
        LoadData();
    }
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
        int index = Inventory.FindIndex(item => item.type == type);
        if (index != -1)
        {
            
            Currency existingItem = Inventory[index];
            existingItem.quantity -= quantity;
            Inventory[index] = existingItem;

            if (existingItem.quantity <= 0)
            {
                Inventory.Remove(existingItem);
            }
        }
    }
    public int GetCurrencyQuantity(CurrencyType type)
    {
        Currency currency = Inventory.Find(item => item.type == type);
        if (currency.type == type)
        {
            return currency.quantity;
        }
        return 0; // Trả về 0 nếu không tìm thấy loại tiền tệ
    }
    public void SaveData()
    {
        foreach (Currency currency in Inventory)
        {
            string keyPrefix = currency.type.ToString();
            PlayerPrefs.SetInt(keyPrefix , currency.quantity);
        }
        PlayerPrefs.SetInt("isSaveCurrency", 1);
        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        if (PlayerPrefs.GetInt("isSaveCurrency", 0) == 1)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                string keyPrefix = Inventory[i].type.ToString();
                int quantity = PlayerPrefs.GetInt(keyPrefix, 1);
                int index = Inventory.FindIndex(item => item.type.ToString() == keyPrefix);
                if (index != -1)
                {

                    Currency existingItem = Inventory[index];
                    existingItem.quantity = quantity;
                    Inventory[index] = existingItem;
                }

            }
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
