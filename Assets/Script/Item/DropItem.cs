using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private List<Item> itemList = new List<Item>();
    float separationDistance = 0.5f;
    void Start()
    {
    }

   List <Item> GetDropItem()
    {
        int RanDom = Random.Range(1, 101);
        List<Item> itemList = new List<Item>();
        foreach (Item item in this.itemList)
        {

            if (RanDom <= item.dropChange)
            {
                itemList.Add(item);
            }
        }
        if (itemList.Count > 0)
        {
            Item dropitem = itemList[Random.Range(0, itemList.Count)];

            return itemList;
        }
        return null;
    }
    public void CreateItem(Vector3 spawnPosition)
    {
       List<Item> dropitem = GetDropItem();
        if (dropitem != null)
        {
            for (int i = 0; i < dropitem.Count; i++)
            {
                Vector3 spawnPositionNew = new Vector3(spawnPosition.x + i * separationDistance, spawnPosition.y + 0.4f, spawnPosition.z);
                Item lootObject= Instantiate(dropitem[i], spawnPositionNew, Quaternion.identity);
                Item lootScript = lootObject.GetComponent<Item>();
                lootScript.PlayBurstAnimation();
            }
        }
    }
}
