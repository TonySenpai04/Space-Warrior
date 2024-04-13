using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   // private bool gamePaused = false;
    public static GameManager instance;
    public GridController GridController;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
       // gamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
       // gamePaused = false;
    }

    void StopGame()
    {
        
    }

    void StartGame()
    {
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GridController.Restart();

    }

}
