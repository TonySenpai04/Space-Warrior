using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public SpriteRenderer Head;
    public List<Sprite> HeadSprites;
    public Animator Animator;
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

    }
    public virtual void Walk()
    {
        SetHead(0);
        Animator.SetBool("Walk", true);
    }
    public virtual void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    // Play Die animation.
    public virtual void Die()
    {
        Animator.SetTrigger("Death");
    }


    public virtual void SetHead(int index)
    {
        //if (index != 2 ) return;

        if (index < HeadSprites.Count)
        {
            Head.sprite = HeadSprites[index];
        }
    }

}
