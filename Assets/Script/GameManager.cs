using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GridController GridController;
    public CurrencyManager currencyManager;
    public SaveWeaponData weaponData;
    public SavePetData petData;
    public SaveBottleData saveBottleData;
    public List<Planet> planets;
    public SaveCharacterData characterData;

    void Start()
    {

    }

    void Update()
    {
        
    }
    public void OnApplicationQuit()
    {
        

    }
    public void SaveGame()
    {
        weaponData.SaveData();
        currencyManager.SaveData();
        petData.SaveData();
        saveBottleData.SaveData();
        characterData.SaveData();
        foreach (Planet planet in planets)
        {
            planet.SaveAreaStates();
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveGame();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; 

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }


}
