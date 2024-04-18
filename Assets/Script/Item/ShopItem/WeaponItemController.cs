using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemController : MonoBehaviour
{
    [SerializeField] private List<ShopItem> weaponItems;
    [SerializeField] private List<GenericWeapon> weapons;
    private void Start()
    {
        ShopItem[] shopItems = GetComponentsInChildren<ShopItem>();
        foreach (ShopItem item in shopItems)
        {
            weaponItems.Add(item);
        }
        SortItemsByPrice();
    }

    private void SortItemsByPrice()
    {
        for (int i = 0; i < weaponItems.Count - 1; i++)
        {
            for (int j = 0; j < weaponItems.Count - i - 1; j++)
            {
                if (weaponItems[j].GetPrice() > weaponItems[j + 1].GetPrice())
                {
                    ShopItem temp = weaponItems[j];
                    weaponItems[j] = weaponItems[j + 1];
                    weaponItems[j + 1] = temp;
                }
            }
        }
    }

}
