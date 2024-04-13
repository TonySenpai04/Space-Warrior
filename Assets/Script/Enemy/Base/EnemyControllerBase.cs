using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyControllerBase : MonoBehaviour
{
    [SerializeField] protected Enemy enemyData;
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject floatingTextPrefab;
    protected IMove move;
    [SerializeField] protected bool isDead;
    [SerializeField] protected Vector3 offsetFloatingtext;
    public virtual void Start()
    {
        InitializeVariables();

    }
    public virtual bool IsDead()
    {
        return isDead;
    }
    public virtual void InitializeVariables()
    {
        enemyData = GetComponent<Enemy>();
        player = FindAnyObjectByType<PlayerController>().transform;
        enemyData.WalkAnim();
        move = new EnemyMove(speed, this.gameObject);

    }
    public virtual void Update()
    {
        
    }
    public virtual void Move()
    {
        move.Move();
    }
    public virtual void Attack()
    {

    }
   
}
