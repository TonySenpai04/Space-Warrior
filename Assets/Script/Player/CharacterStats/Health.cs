using UnityEngine;

public class Health : IHealth
{
    private float health;
    private float currentHealth;
    private float baseHealth;
    public Health(float health)
    {
        this.health = health;
        currentHealth = health;
        baseHealth = health;
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
       currentHealth = health;
    }

    public void Increasehealth(float amount)
    {
        health += amount;
    }

    public float GetBaseHealth()
    {
        return baseHealth;
    }
}

