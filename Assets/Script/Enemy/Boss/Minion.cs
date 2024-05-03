using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Minion:Enemy
{
  
    [SerializeField] private float speed;
    [SerializeField] public Transform owner;
    public override void  Awake()
     {
        base.Awake();
        WalkAnim();
     }
    public override void Update()
    {
        if (currentHealth > 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }
    public override void TakeDamage(float dam, Color color)
    {
        currentHealth -= dam;
        healthUI.TakeDamageUI(dam, color);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DieAnim();

        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if (player)
        {
            CharacterStats.instance.health.TakeDamage((int)CharacterStats.instance.health.GetHealth()/10);
            owner.GetComponent<Enemy>().currentHealth += owner.GetComponent<Enemy>().health/10;
            if (owner.GetComponent<Enemy>().currentHealth>owner.GetComponent<Enemy>().health)
                owner.GetComponent<Enemy>().currentHealth=owner.GetComponent<Enemy>().health;
            
            Destroy(this.gameObject);
        }
    }
    public override IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        if (CharacterStats.instance.level.GetLevel() < 10)
        {
            int experienceGained = Mathf.RoundToInt(baseExperience * Mathf.Pow(experienceIncreaseRate, CharacterStats.instance.level.GetLevel() - 1));
            CharacterStats.instance.level.GainExperience(experienceGained);
        }
        else
        {
            int experienceGained = Mathf.RoundToInt(baseExperience * Mathf.Pow(experienceIncreaseRate - 0.4f, CharacterStats.instance.level.GetLevel() - 1));
            CharacterStats.instance.level.GainExperience(experienceGained);
        }
        gameObject.SetActive(false);
    }


}