using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
[CreateAssetMenu(fileName = "Character Data", menuName = "Character Data")]
[System.Serializable]
public class ChacracterData : ScriptableObject
{
    public string characterName;
    public float health;
    public float mana;
    public float damage;
    public int level;
    public bool isUnlock;
    public float critRate;
    public List<SkillBase> skillBases;
    public float healthGrowthRate = 0.1f;
    public float manaGrowthRate = 0.05f;
    public float damageGrowthRate = 1.5f;
    public float critGrowthRate = 1f;

    public ChacracterData(string name, float health, float mana, float damage, int startLevel, bool unlockStatus, float crit, List<SkillBase> skills)
    {
        characterName = name;
        this.health = health;
        this.mana = mana;
        this.damage = damage;
        level = startLevel;
        isUnlock = unlockStatus;
        critRate = crit;
        skillBases = skills;
    }
    public void UpgradeCharacter(int newLevel)
    {
        level = newLevel;
        health = CalculateNewHealth();
        mana = CalculateNewMana();
        damage = CalculateNewDamage();
        critRate = CalculateNewCritRate();
    }

    private float CalculateNewHealth()
    {
        return health * (1 + healthGrowthRate * level);
    }

 
    private float CalculateNewMana()
    {
        return mana * (1 + manaGrowthRate * level);
    }

    private float CalculateNewDamage()
    {
        return damage * (1 + damageGrowthRate * level);
    }
    private float CalculateNewCritRate()
    {
        return critRate * (1 + critGrowthRate * level);
    }


}

