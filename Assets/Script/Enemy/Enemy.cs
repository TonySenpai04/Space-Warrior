using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public SpriteRenderer Head;
    public List<Sprite> headSprites;
    public Animator animator;
    public float health = 100;
    public float currentHealth;
    public Transform body;
    public EnemyType enemyType;
    public enum EnemyType
    {
        Fly,
        Ground
    }
    public virtual void Awake()
    {
        currentHealth = health;
        animator = GetComponent<Animator>();

    }
    public virtual void Walk()
    {
        SetHead(0);
        animator.SetBool("Walk", true);
    }
    public virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    // Play Die animation.
    public virtual void Die()
    {
        animator.SetTrigger("Death");
    }


    public virtual void SetHead(int index)
    {
        //if (index != 2 ) return;

        if (index < headSprites.Count)
        {
            Head.sprite = headSprites[index];
        }
    }

}
