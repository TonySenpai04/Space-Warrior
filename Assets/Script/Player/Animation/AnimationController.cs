using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationControllerBase
{
    protected override void  Start()
    {
        base.Start();
        Move();
    }

    
    public override void Idle()
    {
        animator.SetBool("move", false);
    }
    public override void Move()
    {
        animator.SetBool("move", true);
    }
}
