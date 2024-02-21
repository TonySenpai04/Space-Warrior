using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private MovementControllerBase movementController;
    [SerializeField]private ShootingControllerBase shootingController;
    [SerializeField] private AnimationControllerBase animationController;
    [SerializeField] private float damage=5f;
    public static PlayerController instance;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask mask;
    public float Damage { get => damage;}
    private void Start()
    {
        instance=this;
    }
    private void Update()
    {
        shootingController.Shoot();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius,mask);
        if (hitColliders.Length > 0 )
        {
            Enemy firstEnemy = null;
            foreach (var item in hitColliders)
            {
                var enemy = item.GetComponent<Enemy>();
                if (enemy!=null)
                {
                    if (enemy.currentHealth>=0)
                    {
                        firstEnemy = enemy;
                        break;
                    }
                   
                }

            }
            if (firstEnemy != null)
            {
                if (firstEnemy.enemyType == Enemy.EnemyType.Fly)
                {
                    shootingController.LookAtMonster(new Vector3(firstEnemy.transform.position.x, transform.position.y + 1.25f, transform.position.z));
                }
                else
                {
                    shootingController.LookAtMonster(firstEnemy.transform.position);
                }
                movementController.StopMove();
                animationController.Idle();
                shootingController.StartShooting();
                return;
            }

        }
        else
        {
            movementController.CanMove();
            shootingController.StopShooting();
            animationController.Move();
            shootingController.StopShooting();
        }
    }
    private void FixedUpdate()
    {
        movementController.Move();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


}
