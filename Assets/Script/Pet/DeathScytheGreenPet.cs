using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeathScytheGreenPet : Pet
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LineController linePrefab;
    [SerializeField] private LineController line;
    [SerializeField] private Transform posStartLine;
    [SerializeField] private float damage;
    [SerializeField] private float damageIncreasePerLevel;
    public override void Start()
    {
        InitializeVariables();
    }
    public void InitializeVariables()
    {
 
        line = Instantiate(linePrefab);
        line.gameObject.SetActive(false);
        player = FindAnyObjectByType<PlayerController>();
 
    }
    private void Update()
    {
        SetDamge();
        ActivateSkill();
    }
    public void SetDamge()
    {
        this.damage = Mathf.Ceil (player.Damage/ damageIncreasePerLevel);
        line.SetDamage(this.damage);
    }
    public override void ActivateSkill()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, mask);
        if (hitColliders.Length > 0)
        {
            Enemy firstEnemy = FindFirstValidEnemy(hitColliders);
            if (firstEnemy != null)
            {
                SetLineTarget(firstEnemy);
                line.gameObject.SetActive(true);
            }
        }
        else
        {
            line.gameObject.SetActive(false);
        }
    }

    private Enemy FindFirstValidEnemy(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            var enemy = item.GetComponent<Enemy>();
            if (enemy != null && enemy.currentHealth >= 0)
            {
                return enemy;
            }
        }
        return null;
    }

    private void SetLineTarget(Enemy enemy)
    {
        Vector3 targetPosition = (enemy.enemyType == Enemy.EnemyType.Fly) ?
            new Vector3(enemy.transform.position.x, line.transform.position.y + 1.25f, line.transform.position.z) :
            new Vector3(enemy.transform.position.x, line.transform.position.y, line.transform.position.z);

        line.AssignTarget(posStartLine.transform.position, targetPosition);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
