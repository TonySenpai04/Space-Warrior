using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: IDamage
{
  
    public float damage;
    public float baseDamge;
    public float critRate;

    public Damage(float damage,float critRate)
    {
        this.damage = damage;
        this.baseDamge = damage;
        this.critRate = critRate;
    }

    public float GetBaseDamage()
    {
        return this.baseDamge;
    }

    public float GetCritRate()
    {
        return this.critRate;
    }

    public float GetDam()
    {
        return damage;
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }

    public void SetCritRate(float crit)
    {
        this.critRate= crit;
    }

    public void SetDam(float dam)
    {
        damage = dam;
    }
}
