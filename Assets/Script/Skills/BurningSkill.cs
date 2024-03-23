using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BurningSkill : SkillBase
{
    [SerializeField] private float burnRate = 0.1f; 
    [SerializeField] private float tickRate = 1f; 
    [SerializeField] private float duration = 3f;

    [SerializeField] private bool isBurning = false; 
    [SerializeField] private float timer = 0f; 
    [SerializeField] private Enemy targetEnemy;
    [SerializeField] private float timerSkill;
    public override void Update()
    {
        CheckSkillActivation();

        if (isBurning && isAbilityCooldown)
        {
            HandleBurningSkill();
        }
    }

    
    private void CheckSkillActivation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ActivateSkill();
        }
    }
    private void ResetTimer()
    {
        timerSkill = 0f;
        timer = 0f;
    }
    
    private void HandleBurningSkill()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Enemy>())
            {
                targetEnemy = hit.collider.gameObject.GetComponent<Enemy>();

            }
        }

        if (targetEnemy != null)
        {
            UpdateTimers();
        }

        if (timer >= tickRate)
        {
            if (targetEnemy != null && targetEnemy.currentHealth>=0)
            {
                targetEnemy.TakeDamage(burnRate * targetEnemy.health, Color.magenta);
                
            }

            timer = 0f;
        }

        if (timerSkill >= duration || targetEnemy == null || targetEnemy.currentHealth<=0)
        {
            isBurning = false;
            ResetTimer();
            targetEnemy = null;
        }
    }

    private void UpdateTimers()
    {
        timer += Time.deltaTime;
        timerSkill += Time.deltaTime;
    }

    public override void ActivateSkill()
    {
        isBurning = true;
    }

}
