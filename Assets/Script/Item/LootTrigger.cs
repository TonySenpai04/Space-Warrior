using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Loot item = gameObject.GetComponent<Loot>();

        if (collision.gameObject.GetComponent<PlayerController>())
        {
            ItemManager.instance.AddItem(item.typeItem, item.count);
            Destroy(item.gameObject);
        }
    }
 

}
