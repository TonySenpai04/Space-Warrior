using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyControllerBase
{
    public static MonsterController instance;
    public void Awake()
    {
        instance = this; 
    }
  
    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        float distance = transform.position.x - player.transform.position.x;
        if (distance >= 3f)
        {
            Move();
        }


    }
    public override void TakeDamage(float dam)
    {
        enemyData.currentHealth -= (int)dam;
        var floatingText = Instantiate(floatingTextPrefab.gameObject,
            new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1),
            Random.Range(transform.position.y + offsetFloatingtext.y, transform.position.y + offsetFloatingtext.y+1f),
            transform.position.z), Quaternion.identity, transform);
        floatingText.GetComponent<TextMesh>().text = ((int)dam).ToString();
        if (enemyData.currentHealth <= 0)
        {
            enemyData.Die();
            StartCoroutine(Death());
        }
    }
    public override IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        if (GetComponent<LootBag>())
        {
            GetComponent<LootBag>().CreateItem(this.transform.position);
        }
        gameObject.SetActive(false);
    }

}
