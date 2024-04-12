using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class BurningSkill : SkillBase
{
    [SerializeField] private float burnRate = 0.1f; 
    [SerializeField] private float tickRate = 1f; 
    [SerializeField] private float duration = 3f;

    [SerializeField] private bool isBurning = false; 
    [SerializeField] private float timer = 0f; 
    [SerializeField] private Enemy targetEnemy;
    [SerializeField] private float timerSkill;

    public bool isSelectingTarget = false;
    public Image targetIcon;
    public GameObject tartgetPanel;
    public override void Start()
    {
        base.Start();
        targetIcon.gameObject.SetActive(false);
    }
    public override void Update()
    {
      

        if (isBurning && isAbilityCooldown )
        {
            
            HandleBurningSkill();
        }
        if (isSelectingTarget)
        {
            MoveTargetIconWithMouse();
            HandleBurningSkill();

        }

    }

    public override void StartSelectTarget()
    {
        isSelectingTarget = true;
        Time.timeScale = 0f;
        tartgetPanel.gameObject.SetActive(true);
        targetIcon.gameObject.SetActive( true );

    }
    private void ResetTimer()
    {
        timerSkill = 0f;
        timer = 0f;
    }
    private void MoveTargetIconWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        targetIcon.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isSelectingTarget = false;
        targetIcon.gameObject.SetActive(false);
        tartgetPanel.gameObject.SetActive(false);
    }


    private void HandleBurningSkill()
    {

        // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Enemy>())
                {
                    targetEnemy = hit.collider.gameObject.GetComponent<Enemy>();
                    
                }
            }
        }
      
        if (targetEnemy != null)
        {
            ResumeGame();
            UpdateTimers();
            isBurning = true;
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
        
 
        CharacterStats.instance.mana.UseMana(manaConsumption);
    }

}
