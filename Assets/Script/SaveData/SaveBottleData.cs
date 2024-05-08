using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBottleData : MonoBehaviour
{
    public List<Bottle> bottles;
    private void Awake()
    {
        LoadData();
    }
    public  void SaveData()
    {
        foreach (Bottle bottle in bottles)
        {
            string keyPrefix = bottle.bottleName;
            PlayerPrefs.SetInt(keyPrefix, bottle.count);
        }

        PlayerPrefs.SetInt("isSaveBottle", 1);
        PlayerPrefs.Save();
    }
    public  void LoadData()
    {
        if (PlayerPrefs.GetInt("isSaveBottle", 0) == 1)
        {
            foreach (Bottle bottle in bottles)
            {
                string keyPrefix = bottle.bottleName;
                int quantity = PlayerPrefs.GetInt(keyPrefix, 1);
                bottle.count = quantity;
            }

        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
