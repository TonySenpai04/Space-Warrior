using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Currency item = collision.gameObject.GetComponent<Currency>();

        if (item != null)
        {
            item.TriggerItem();
        }
    }

}
