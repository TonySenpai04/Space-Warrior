using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    public ISubject subject;
    public Timer timer;
    public WeaponControllerBase weaponController;
    void Start()
    {
        subject = new ConcreteSubject();
        subject.RegisterObserver(timer);
        GetComponent<Button>().onClick.AddListener(Restart);
    }

 
    public void Restart()
    {
        subject.RegisterObserver(PlanetManager.instance.GetCurrentArea());
        subject.RegisterObserver(GridManager.instance.GetCurrentGrid());
        subject.NotifyObservers();
        weaponController.Resstart();
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
        //gridController.Restart();
        //PlanetManager.instance.Restart();

    }

    
}
