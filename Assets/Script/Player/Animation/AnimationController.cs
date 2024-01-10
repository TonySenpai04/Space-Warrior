using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationControllerBase
{
   
    protected override void  Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Shooting();
        }else if (Input.GetKey(KeyCode.S))
        {
            Walk();
        }
    }
    public void Shooting()
    {
        animator.SetBool("isShoot", true);
    }
    public void Walk()
    {
        animator.SetBool("isShoot", false);
    }
}
