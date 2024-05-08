using System.Collections;
using System.Collections.Generic;
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
