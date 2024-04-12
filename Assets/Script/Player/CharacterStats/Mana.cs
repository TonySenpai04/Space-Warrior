using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : IMana
{
    private float mana;
    private float currentMana;
    private float baseMana;

    public Mana(float mana)
    {
        this.mana = mana;
        this.currentMana = mana;
        this.baseMana = mana;
    }
    public void UseMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
            currentMana = 0;
    }

    public void RestoreMana(float amount)
    {
        currentMana += amount;
        if (currentMana > mana)
            currentMana = mana;
    }

    public float GetMana()
    {
        return mana;
    }

    public float GetCurrentMana()
    {
        return currentMana;
    }

    public void SetMana(float value)
    {
        mana= value;
        currentMana= value;
    }

    public void IncreaseMana(float amount)
    {
        mana += amount;
    }

    public float GetBaseMana()
    {
       return baseMana;
    }
}
