using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPet : Pet
{
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private float additionalCritRate;
    public override void Start()
    {
        description = GetSkillDescription();
        ActivateSkill();
    }
    public override void ActivateSkill()
    {
       float critRate= characterStats.damage.GetCritRate();
       characterStats.damage.SetCritRate(critRate+ additionalCritRate);

    }
    public override string GetSkillDescription()
    {
        return "Increases the critical hit rate of the character's damage by " + additionalCritRate + "%"; 
    }
    public override void Upgrade()
    {
        additionalCritRate += 3;
    }
}
