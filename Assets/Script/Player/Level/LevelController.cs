using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int experience = 0;
    [SerializeField]private int experienceNeededForNextLevel = 20;

    public int Level { get => level; set => level = value; }

    void Start()
    {
        
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceNeededForNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Level++;
        PlayerController.instance.Damage+=5;
        experience = experience- experienceNeededForNextLevel ;
        experienceNeededForNextLevel += (int)(experienceNeededForNextLevel * 0.1f); 
        MonsterSpawnManager.instance.SetLevelSpawn(Level);
    }
}
