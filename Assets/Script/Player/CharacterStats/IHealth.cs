public interface IHealth
{
    public float GetHealth();
    public float GetCurrentHealth();
    public void SetHealth(float value);
    public void TakeDamage(int damage);

    public void Heal(int amount);
    public void Increasehealth(float amount);
    public float GetBaseHealth();
}