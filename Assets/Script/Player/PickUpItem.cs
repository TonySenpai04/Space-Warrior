using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Item item = collision.gameObject.GetComponent<Item>();

        if (item != null)
        {
            item.TriggerItem();
        }
    }

}
