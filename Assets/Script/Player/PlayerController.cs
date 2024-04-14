using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private MovementControllerBase movementController;
    [SerializeField] private WeaponControllerBase weaponController;
    [SerializeField] private AnimationControllerBase animationController;
    [Space]
    [Header("Info")]
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask mask;


    private void Start()
    {
        
       
    }
    
    private void Update()
    {
        if (!CharacterStats.instance.isDead)
        {
            if (!PlanetManager.instance.IsAreaFinish())
            {

                HandleShooting();
                HandleEnemyDetection();
            }
        }
    }

    private void HandleShooting()
    {
        weaponController.Shoot();
    }

    private void HandleEnemyDetection()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, mask);

        if (hitColliders.Length > 0)
        {
            HandleEnemyFound(hitColliders);
        }
        else
        {
            HandleNoEnemy();
        }
    }

    private void HandleEnemyFound(Collider2D[] hitColliders)
    {
        Enemy firstEnemy = null;
        foreach (var item in hitColliders)
        {
            var enemy = item.GetComponent<Enemy>();
            if (enemy != null && enemy.currentHealth >= 0)
            {
                firstEnemy = enemy;
                break;
            }
        }

        if (firstEnemy != null)
        {
            LookAtEnemy(firstEnemy);
            HandleEnemyEngagement();
        }
    }

    private void LookAtEnemy(Enemy enemy)
    {
        Vector3 targetPosition = (enemy.enemyType == Enemy.EnemyType.Fly) ?
            new Vector3(enemy.transform.position.x, transform.position.y + 1.25f, transform.position.z) :
            enemy.transform.position;

        weaponController.LookAtMonster(targetPosition);
    }
    private void HandleEnemyEngagement()
    {
        movementController.StopMove();
        animationController.Idle();
        weaponController.StartShooting();
    }

    private void HandleNoEnemy()
    {
        movementController.CanMove();
        weaponController.StopShooting();
        animationController.Move();
        weaponController.StopShooting();
    }

    private void FixedUpdate()
    {
        if (!CharacterStats.instance.isDead)
        {
            if (!PlanetManager.instance.IsAreaFinish())
            {
                movementController.Move();
            }
        }
       
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


}
