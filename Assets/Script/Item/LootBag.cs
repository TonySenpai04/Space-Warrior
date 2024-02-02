using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [SerializeField] private List<Loot> lootList = new List<Loot>();
    float separationDistance = 0.5f;
    void Start()
    {
    }

   List <Loot> GetDropItem()
    {
        int RanDom = Random.Range(1, 101);
        List<Loot> itemList = new List<Loot>();
        foreach (Loot item in lootList)
        {

            if (RanDom <= item.dropChange)
            {
                itemList.Add(item);
            }
        }
        if (itemList.Count > 0)
        {
            Loot dropitem = itemList[Random.Range(0, itemList.Count)];

            return itemList;
        }
        return null;
    }
    public void CreateItem(Vector3 spawnPosition)
    {
       List<Loot> dropitem = GetDropItem();
        if (dropitem != null)
        {
            for (int i = 0; i < dropitem.Count; i++)
            {
                Vector3 spawnPositionNew = new Vector3(spawnPosition.x + i * separationDistance, spawnPosition.y + 0.4f, spawnPosition.z);
                Loot lootObject= Instantiate(dropitem[i], spawnPositionNew, Quaternion.identity);
                Loot lootScript = lootObject.GetComponent<Loot>();
                lootScript.PlayBurstAnimation();
            }
        }
    }
}
