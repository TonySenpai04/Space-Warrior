using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IMove, IStopMove,ICanMove
{
    private Rigidbody2D rigidbody;
    private bool isMove = true;
    private float originalSpeed;
    private float speed;

    public Move(Rigidbody2D rigidbody, float speed)
    {
        this.rigidbody = rigidbody;
        this.speed = speed;
        originalSpeed = speed;

    }

    

    void IMove.Move()
    {
        if (isMove)
        {
            rigidbody.velocity = new Vector3(speed * Time.deltaTime * 1, rigidbody.velocity.y, 0);
        }
    }
    
    public void StopMove()
    {
        isMove = false;
        rigidbody.velocity = Vector2.zero;
    }

    public void CanMove()
    {
        isMove = true;
    }
}
