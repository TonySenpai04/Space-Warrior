using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private ISubject subject;
    [SerializeField] private Timer timer;
    [SerializeField] private WeaponControllerBase weaponController;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private SkillAbility skill;
    [SerializeField] private PetManager petManager;
    void Start()
    {
        subject = new ConcreteSubject();
        subject.RegisterObserver(timer);
        subject.RegisterObserver(characterStats);
        subject.RegisterObserver(PlanetManager.instance.GetCurrentArea());
        subject.RegisterObserver(GridManager.instance.GetCurrentGrid());
        subject.RegisterObserver(petManager);
       GetComponent<Button>().onClick.AddListener(ReplayGame);
    }


    public void ReplayGame()
    {
        subject.RegisterObserver(skill);
        subject.NotifyObservers();
        weaponController.Resstart();
        Time.timeScale = 1.0f;
        deathPanel.gameObject.SetActive(false);
        characterStats.isDead = false;

    }

}
