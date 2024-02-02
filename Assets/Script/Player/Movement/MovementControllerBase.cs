using UnityEngine;

public class MovementControllerBase:MonoBehaviour
{
    protected IMove move;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rigidbody2d;
    protected virtual void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }
    public virtual void Move()
    {
        move.Move();
    }
    public virtual void StopMove()
    {

    }
    public virtual void CanMove()
    {

    }
}