using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class PetData
{
    public bool isUnlock;
    public bool isUse;
    public int level;
}
public class SavePetData : MonoBehaviour
{
    [SerializeField] private List<Pet> pets;
    private const string UnlockKeyPrefix = "PetUnlock_";
    private const string UseKeyPrefix = "PetUse_";
    private const string LevelKeyPrefix = "PetLevel_";
    private void Awake()
    {
        LoadPetData();
    }
    public void SaveData()
    {
        //List<PetData> petDataList = new List<PetData>();

        //foreach (Pet pet in pets)
        //{
        //    PetData petData = new PetData
        //    {
        //        isUnlock = pet.isUnlock,
        //        isUse = pet.isUse,
        //        level = pet.level
        //    };

        //    petDataList.Add(petData);
        //}

        //string jsonData = JsonUtility.ToJson(petDataList);
        //File.WriteAllText(GetSavePath(), jsonData);
        foreach (Pet pet in pets)
        {
            PlayerPrefs.SetInt(UnlockKeyPrefix + pet.name, pet.isUnlock ? 1 : 0);
            PlayerPrefs.SetInt(UseKeyPrefix + pet.name, pet.isUse ? 1 : 0);
            PlayerPrefs.SetInt(LevelKeyPrefix + pet.name, pet.level);
        }
        PlayerPrefs.Save();
    }


    public void LoadPetData()
    {
        //string jsonData = File.ReadAllText(GetSavePath());
        //List<PetData> petDataList = JsonUtility.FromJson<List<PetData>>(jsonData);

        //for (int i = 0; i < pets.Count && i < petDataList.Count; i++)
        //{
        //    pets[i].isUnlock = petDataList[i].isUnlock;
        //    pets[i].isUse = petDataList[i].isUse;
        //    pets[i].level = petDataList[i].level;
        //}
        foreach (Pet pet in pets)
        {
            int isUnlocked = PlayerPrefs.GetInt(UnlockKeyPrefix + pet.name, 0);
            pet.isUnlock = isUnlocked == 1;

            int isUsed = PlayerPrefs.GetInt(UseKeyPrefix + pet.name, 0);
            pet.isUse = isUsed == 1;

            int level = PlayerPrefs.GetInt(LevelKeyPrefix + pet.name, 1);
            pet.level = level;
        }
    }
    public void UpdateSkillAfterLoadData()
    {
        foreach (Pet pet in pets)
        {

            pet.UpdateSkillAfterLoadData();
        }
    }
    //private string GetSavePath()
    //{
    //    return Path.Combine(Application.persistentDataPath, savePath);
    //}


    private void OnApplicationQuit()
    {
        SaveData();
    }
}
