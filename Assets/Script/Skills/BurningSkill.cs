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
    [SerializeField] private float timer ; 
    [SerializeField] private Enemy targetEnemy;
    [SerializeField] private float timerSkill;

    [SerializeField] private bool isSelectingTarget = false;
    [SerializeField] private Image targetIcon;
    [SerializeField] private GameObject tartgetPanel;
    [SerializeField] private  GameObject flameEffect;
    [SerializeField] private GameObject flameEffectPrefab;
    public override void Start()
    {
        base.Start();
        timer = tickRate;
        targetIcon.gameObject.SetActive(false);
        flameEffect= Instantiate(flameEffectPrefab);
        flameEffect.gameObject.SetActive(false);
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
    public  void ResetTimer()
    {
        timerSkill = 0f;
        timer = tickRate;
       
    }
    public override void Restart()
    {
        base.Restart();
        isAbilityCooldown = false;
        currentAbilityCooldown = 0f;
        timerSkill = 0f;
        timer = tickRate;
        targetEnemy = null;

    }
    private void MoveTargetIconWithMouse()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition.z = 10f;
        //targetIcon.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Lấy thông tin về ngón tay đầu tiên

            Vector3 touchPosition = touch.position;
            touchPosition.z = 10f; // Đảm bảo rằng z không thay đổi khi chuyển đổi tọa độ

            // Chuyển đổi tọa độ màn hình của ngón tay thành tọa độ thế giới
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Thiết lập vị trí của biểu tượng mục tiêu theo vị trí của ngón tay
            targetIcon.transform.position = worldPosition;
        }
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
        if (/*Input.GetMouseButtonDown(0) */Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isSelectingTarget)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Enemy>())
                {
                    targetEnemy = hit.collider.gameObject.GetComponent<Enemy>();
                    
                }
            }
            else
            {
                ResumeGame();
                SkillManager.instance.skillAbility.RestartAbility1();
            }
        }
      
        if (targetEnemy != null)
        {
            ResumeGame();
            UpdateTimers();
            if (targetEnemy.enemyType == Enemy.EnemyType.Ground)
            {
                flameEffect.transform.position = new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y + 1.6f, targetEnemy.transform.position.z);
            }
            else
            {
                flameEffect.transform.position = new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y + 2f, targetEnemy.transform.position.z);
            }
            flameEffect.gameObject.SetActive(true);
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
            flameEffect.gameObject.SetActive(false);
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
