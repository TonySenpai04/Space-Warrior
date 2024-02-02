using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MovementControllerBase
{
    public static MovementController instance;
    protected override void Start()
    {
        base.Start();
        instance = this;
        move = new Move(rigidbody2d, speed);
    }
    public override void Move()
    {
        base.Move();
    }
    public override void StopMove()
    {
        IStopMove stopMove=(IStopMove) move;
        stopMove.StopMove();
    }
    public override void CanMove()
    {
        ICanMove canMove = (ICanMove)move;
        canMove.CanMove();
    }
}
