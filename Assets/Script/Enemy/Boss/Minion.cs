using Unity.VisualScripting;
using UnityEngine;

public class Minion:Enemy
{
  
    [SerializeField] private float speed;
    [SerializeField] public Transform owner;
    public override void  Awake()
     {
        base.Awake();
     }
    public override void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
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


}