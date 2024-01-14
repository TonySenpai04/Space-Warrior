using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationControllerBase
{
   public static AnimationController instance;
    protected override void  Start()
    {
        base.Start();
        instance = this;
        Move();
    }

    
    public void Idle()
    {
        animator.SetBool("move", false);
    }
    public void Move()
    {
        animator.SetBool("move", true);
    }
}
