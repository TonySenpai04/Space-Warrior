using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Components")]
    public SpriteRenderer Head;
    public List<Sprite> headSprites;
    public Animator animator;
    public Transform body;
    public EnemyType enemyType;
    public LevelController levelController;
    public EnemyHealthUIBase healthUI;
    [Space]
    [Header("Info")]
    public float health;
    public float currentHealth;
    public int baseExperience = 5;
    public float experienceIncreaseRate = 1.1f;
    public float baseHealth;
    public enum EnemyType
    {
        Fly,
        Ground
    }
    public virtual void Awake()
    {
        InitializeVariables();
        InitializeComponents();
    }
    public virtual void InitializeVariables()
    {
        currentHealth = health;
        baseHealth = health;
    }
    public virtual void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        levelController = FindAnyObjectByType<LevelController>();
        healthUI = GetComponentInChildren<EnemyHealthUIBase>();
        SetHead(0);
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
        StartCoroutine(Death());
    }

    public virtual void Update()
    {
        //float gameTime = Time.time;
        //health =  baseHealth + 0.3f * gameTime;
    }
    public virtual void SetHead(int index)
    {
        //if (index != 2 ) return;

        if (index < headSprites.Count)
        {
            Head.sprite = headSprites[index];
        }
    }
    public virtual void TakeDamage(float dam,Color color)
    {
        currentHealth -= dam;
        healthUI.TakeDamageUI(dam, color);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
           
        }
        
        
    }
    public virtual IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        if (GetComponent<DropItem>())
        {
            GetComponent<DropItem>().CreateItem(this.transform.position);
        }
        if (levelController != null)
        {
            int experienceGained = Mathf.RoundToInt(baseExperience * Mathf.Pow(experienceIncreaseRate, levelController.Level - 1));
            levelController.GainExperience(experienceGained);
        }
        gameObject.SetActive(false);
    }

}
