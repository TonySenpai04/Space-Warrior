using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [System.Serializable]
    public class ItemDrop
    {
        public Item item;
        public int count;
    }

    [SerializeField] private List<ItemDrop> itemList = new List<ItemDrop>();
    float separationDistance = 0.5f;

    List<ItemDrop> GetDropItem()
    {
        int RanDom = Random.Range(1, 101);
        List<ItemDrop> droppedItems = new List<ItemDrop>();
        foreach (ItemDrop itemDrop in itemList)
        {
            if (RanDom <= itemDrop.item.dropChange)
            {
                droppedItems.Add(itemDrop);
            }
        }
        return droppedItems;
    }

    public void CreateItem(Vector3 spawnPosition)
    {
        List<ItemDrop> droppedItems = GetDropItem();
        if (droppedItems != null)
        {
            for (int i = 0; i < droppedItems.Count; i++)
            {
                Vector3 spawnPositionNew = new Vector3(spawnPosition.x + i * separationDistance, spawnPosition.y + 0.4f, spawnPosition.z);
                GameObject lootObject = Instantiate(droppedItems[i].item.gameObject, spawnPositionNew, Quaternion.identity);
                Item lootScript = lootObject.GetComponent<Item>();
                lootScript.dropCount = droppedItems[i].count;
                lootScript.PlayBurstAnimation();
            }
        }
    }
}
