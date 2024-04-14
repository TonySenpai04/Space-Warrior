using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MovementControllerBase
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    protected override void Start()
    {
        base.Start();
        move = new Move(rigidbody2d, speed,clip,audioSource);
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
