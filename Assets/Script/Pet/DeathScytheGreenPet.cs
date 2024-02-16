using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeathScytheGreenPet : Pet
{
    [SerializeField] private GameObject player;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LineController linePrefab;
    [SerializeField] private LineController line;
    [SerializeField] private Transform posStartLine;

    public override void Start()
    {
        line = Instantiate(linePrefab);
        line.gameObject.SetActive(false);
        player =FindAnyObjectByType<PlayerController>().gameObject;
    }
    private void Update()
    {
        ActivateSkill();
    }
    public override void ActivateSkill()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, mask);
        if (hitColliders.Length > 0)
        {
            Enemy firstEnemy = null;
            foreach (var item in hitColliders)
            {
                var enemy = item.GetComponent<Enemy>();
                if (enemy != null)
                {
                    if (enemy.currentHealth >= 0)
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
                    line.AssignTarget(posStartLine.transform.position,new Vector3(firstEnemy.transform.position.x, line.transform.position.y + 1.25f,line.transform.position.z));

                }
                else
                {
                    line.AssignTarget(posStartLine.transform.position, new Vector3(firstEnemy.transform.position.x, line. transform.position.y , line.transform.position.z));
                    
                }
                line.gameObject.SetActive(true);
            }
        }
        else
        {
            line.gameObject.SetActive(false);

        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
