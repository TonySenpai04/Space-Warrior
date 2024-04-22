using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPet : Pet
{
    [SerializeField] private CharacterStats characterStats;
    public override void Start()
    {
        ActivateSkill();
    }
    public override void ActivateSkill()
    {
       float critRate= characterStats.damage.GetCritRate();
       characterStats.damage.SetCritRate(critRate+10);

    }
    
}
