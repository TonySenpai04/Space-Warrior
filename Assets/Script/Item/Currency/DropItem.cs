using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private List<Currency> itemList = new List<Currency>();
    float separationDistance = 0.5f;
    void Start()
    {
    }

   List <Currency> GetDropItem()
    {
        int RanDom = Random.Range(1, 101);
        List<Currency> itemList = new List<Currency>();
        foreach (Currency item in this.itemList)
        {

            if (RanDom <= item.dropChange)
            {
                itemList.Add(item);
            }
        }
        if (itemList.Count > 0)
        {
            Currency dropitem = itemList[Random.Range(0, itemList.Count)];

            return itemList;
        }
        return null;
    }
    public void CreateItem(Vector3 spawnPosition)
    {
       List<Currency> dropitem = GetDropItem();
        if (dropitem != null)
        {
            for (int i = 0; i < dropitem.Count; i++)
            {
                Vector3 spawnPositionNew = new Vector3(spawnPosition.x + i * separationDistance, spawnPosition.y + 0.4f, spawnPosition.z);
                Currency lootObject= Instantiate(dropitem[i], spawnPositionNew, Quaternion.identity);
                Currency lootScript = lootObject.GetComponent<Currency>();
                lootScript.PlayBurstAnimation();
            }
        }
    }
}
