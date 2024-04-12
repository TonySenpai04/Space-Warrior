public interface IMana
{
    public float GetMana();
    public float GetCurrentMana();
    public void SetMana(float value);
    public void UseMana(int amount);
    public void RestoreMana(float mana);
    public void IncreaseMana(float amount);
    public float GetBaseMana();
}