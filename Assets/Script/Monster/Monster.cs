using System;
using System.Collections.Generic;
using System.Linq;
using Assets.FantasyMonsters.Scripts.Tweens;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public SpriteRenderer Head;
    public List<Sprite> HeadSprites;
    public Animator Animator;
    public float health = 100;
    public float currentHealth;
    public Transform body;

    public void Awake()
    {
        currentHealth = health;
       
    }

    public void SetState(MonsterState state)
    {
        Animator.SetInteger("State", (int)state);
    }
    public void Walk()
    {
        SetHead(0);
        Animator.SetBool("Walk",true);
    }
    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    public virtual void Spring()
    {
        ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
    }

    // Play Die animation.
    public void Die()
    {
        Animator.SetTrigger("Death");
    }


    public void SetHead(int index)
    {
        if (index != 2 && Animator.GetInteger("State") == (int)MonsterState.Death) return;

        if (index < HeadSprites.Count)
        {
            Head.sprite = HeadSprites[index];
        }
    }
}
