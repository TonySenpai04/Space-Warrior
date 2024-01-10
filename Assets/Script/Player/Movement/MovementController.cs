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
        move = new Move(rigidbody, speed);
    }
    private void Update()
    {
        move.Move();
    }
    public void StopMove()
    {
        IStopMove stopMove=(IStopMove) move;
        stopMove.StopMove();
    }
    public void CanMove()
    {
        ICanMove canMove = (ICanMove)move;
        canMove.CanMove();
    }
}
