using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugQueen : Boss
{
    [Header("Skill")]
    [SerializeField] private Enemy minionPrefab;
    [SerializeField] private float skillCooldown;
    [SerializeField] private Transform player;
    private ISkillBoss skill;
    public override void Awake()
    {
        base.Awake();
        player=FindAnyObjectByType<EnemySpawnControllerBase>().player;
        skill = new SlugQueenAbility(minionPrefab, skillCooldown, this.transform, player);
    }

    public override void ActiveSkill()
    {
        
        skill.ActiveSkill();
        
    }
    public override void Update()
    {
        base.Update();
        ActiveSkill();
    }

}
