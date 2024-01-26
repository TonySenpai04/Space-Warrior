using UnityEngine;

public class MovementControllerBase:MonoBehaviour
{
    protected IMove move;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rigidbody;
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    public virtual void Move()
    {
        move.Move();
    }
}