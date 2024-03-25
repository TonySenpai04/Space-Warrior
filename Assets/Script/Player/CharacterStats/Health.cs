using UnityEngine;

public class Health : IHealth
{
    public float health;
    public float currentHealth;
    public Health(float health)
    {
        this.health = health;
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > health)
            currentHealth = health;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float value)
    {
       health=value;
    }

    public void Increasehealth(float amount)
    {
        health += amount;
    }
}

