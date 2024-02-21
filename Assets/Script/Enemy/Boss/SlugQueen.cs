using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugQueen : Boss
{
    [Header("Skill")]
    [SerializeField] private Enemy minionPrefab;
    [SerializeField] private float skillCooldown;
    private ISkillBoss skill;
    public override void Awake()
    {
        base.Awake();

        skill = new SlugQueenAbility(minionPrefab, skillCooldown, this.transform);
    }

    public override void ActiveSkill()
    {
        
        skill.ActiveSkill();
        
    }

}
