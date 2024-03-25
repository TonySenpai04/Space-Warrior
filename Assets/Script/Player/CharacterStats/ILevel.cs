public interface ILevel
{
    public void GainExperience(int amount);
    public float GetCurrentExp();
    public float GetExperience();
    public void SetExperience(int experience);
    public int GetLevel();

}