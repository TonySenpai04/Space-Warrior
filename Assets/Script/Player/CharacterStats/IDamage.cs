public interface IDamage
{
    public float GetDam();
    public void SetDam(float dam);
    public void IncreaseDamage(float amount);
    public float GetBaseDamage();
    public float GetCritRate();
    public void SetCritRate(float crit);

}