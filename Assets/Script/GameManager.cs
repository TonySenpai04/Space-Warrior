using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }


}
