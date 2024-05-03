using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetProjectile : GenericProjectile
{
    public override void Awake()
    {
        Destroy(this.gameObject, 3f);
    }
    [System.Obsolete]
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        Minion minion = collision.gameObject.GetComponent<Minion>();
        if (monster != null)
        {
            monster.TakeDamage(monster.health,Color.red);
 
        } 
        if(minion != null)
        {
            minion.TakeDamage(minion.health, Color.red);
        }
       
    }
}
