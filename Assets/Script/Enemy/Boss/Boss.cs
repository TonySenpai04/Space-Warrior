using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected ISkillBoss skillBoss;
    public virtual void ActiveSkill()
    {

    }
    public override void Update()
    {
        base.Update();
        ActiveSkill();
    }
}
