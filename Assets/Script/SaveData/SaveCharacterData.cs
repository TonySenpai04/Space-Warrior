using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaveCharacterData : MonoBehaviour
{
    [SerializeField] private List<ChacracterData> chacractersData;

    private void Awake()
    {

            LoadData();

    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
    public void SaveData()
    {
        foreach (var character in chacractersData)
        {
            string keyPrefix = character.characterName;


            PlayerPrefs.SetFloat(keyPrefix + "health", character.health);
            PlayerPrefs.SetFloat(keyPrefix + "mana", character.mana);
            PlayerPrefs.SetFloat(keyPrefix + "damage", character.damage);
            PlayerPrefs.SetInt(keyPrefix + "level", character.level);
            PlayerPrefs.SetInt(keyPrefix + "isUnlock", character.isUnlock ? 1 : 0);
            PlayerPrefs.SetFloat(keyPrefix + "critRate", character.critRate);

        }
        PlayerPrefs.SetInt("isSaveChracter", 1);
        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        if (PlayerPrefs.GetInt("isSaveChracter", 0) == 1)
        {
            foreach (var character in chacractersData)
            {
                string keyPrefix = character.characterName;

                character.health = PlayerPrefs.GetFloat(keyPrefix + "health", 0f);
                character.mana = PlayerPrefs.GetFloat(keyPrefix + "mana", 0f);
                character.damage = PlayerPrefs.GetFloat(keyPrefix + "damage", 0f);
                character.level = PlayerPrefs.GetInt(keyPrefix + "level", 1);
                character.isUnlock = PlayerPrefs.GetInt(keyPrefix + "isUnlock", 0) == 1 ? true : false;
                character.critRate = PlayerPrefs.GetFloat(keyPrefix + "critRate", 0f);

            }
        }

    }
}
