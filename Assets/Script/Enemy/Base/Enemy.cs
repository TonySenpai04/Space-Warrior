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
    public EnemyHealthUIBase healthUI;
    public Transform hit;
    [Space]
    [Header("Info")]
    public float health;
    public float currentHealth;
    public int baseExperience = 5;
    public float experienceIncreaseRate = 1.5f;
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
        healthUI = GetComponentInChildren<EnemyHealthUIBase>();
        SetHead(0);
    }
    public virtual void WalkAnim()
    {
        SetHead(0);
        animator.SetBool("Walk", true);
    }
    public virtual void AttackAnim()
    {
        animator.SetBool("Walk", false);
        animator.SetTrigger("Attack");
    }

    // Play Die animation.
    public virtual void DieAnim()
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
        SpawnHit();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DieAnim();

        }
        
        
    }
    public virtual IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        if (GetComponent<DropItem>())
        {
            GetComponent<DropItem>().CreateItem(this.transform.position);
        }
        if (CharacterStats.instance.level.GetLevel() < 10)
        {
            int experienceGained = Mathf.RoundToInt(baseExperience * Mathf.Pow(experienceIncreaseRate, CharacterStats.instance.level.GetLevel() - 1));
            CharacterStats.instance.level.GainExperience(experienceGained);
        }
        else
        {
            int experienceGained = Mathf.RoundToInt(baseExperience * Mathf.Pow(experienceIncreaseRate-0.4f, CharacterStats.instance.level.GetLevel() - 1));
            CharacterStats.instance.level.GainExperience(experienceGained);
        }
        gameObject.SetActive(false);
    }
    private void SpawnHit()
    {
        if (hit == null) return;
        //var normalOffset = contactNormal * Random.Range(HitNormalOffset.x, HitNormalOffset.y);
        var Hit = Instantiate(hit.gameObject, transform.position + Vector3.up * 0.5f, Quaternion.identity,transform);
        Destroy(Hit, 0.5f);
    }

}
