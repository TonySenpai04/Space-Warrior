using UnityEngine;

public class Level : ILevel
{
    [SerializeField] private int level = 1;
    [SerializeField] private float currentExperience = 0;
    [SerializeField] private int experienceNeededForNextLevel = 20;
    [SerializeField] private float baseExp;
    [SerializeField] private float experienceMultiplier = 1.2f;

    public Level() {
        this.baseExp = experienceNeededForNextLevel;

    }
  
    public  void GainExperience(int amount)
    {
        currentExperience += amount;
        if (currentExperience >= experienceNeededForNextLevel)
        {
            LevelUp();
        }
    }
    public void Restart()
    {
        level = 1;
        experienceNeededForNextLevel = 20;
        currentExperience = 0;
        baseExp = experienceNeededForNextLevel;
        SkillAbility.instance.UpdateSkill(); 
    }
    void LevelUp()
    {
        level++;
        int newDamage = Mathf.RoundToInt(CharacterStats.instance.damage.GetBaseDamage() * Mathf.Pow(1.35f, level));
        CharacterStats.instance.damage.SetDam(newDamage);
        //
        int newHealth = Mathf.RoundToInt(CharacterStats.instance.health.GetBaseHealth() * Mathf.Pow(1.2f, level));
        CharacterStats.instance.health.SetHealth(newHealth);
        //
        int newMana = Mathf.RoundToInt(CharacterStats.instance.mana.GetBaseMana() * Mathf.Pow(1.2f, level));
        CharacterStats.instance.mana.SetMana(newMana);
        Debug.Log(newDamage);
        currentExperience -= experienceNeededForNextLevel ;
        experienceNeededForNextLevel =(int) Mathf.RoundToInt(baseExp * Mathf.Pow(level, experienceMultiplier));

        SkillAbility.instance.UpdateSkill();

    }

    public float GetCurrentExp()
    {
        return currentExperience;
    }

    public float GetExperience()
    {
        return experienceNeededForNextLevel;
    }

    public void SetExperience(int experience)
    {
        experienceNeededForNextLevel = experience;
    }

    public int GetLevel()
    {
        return level;
    }
}
