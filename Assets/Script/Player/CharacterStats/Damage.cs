using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: IDamage
{
  
    public float damage;

    public Damage(float damage)
    {
        this.damage = damage;   
    }
    public float GetDam()
    {
        return damage;
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }

    public void SetDam(float dam)
    {
        damage = dam;
    }
}
