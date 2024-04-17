using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class SkillBase : MonoBehaviour
{
    public float countdown;
    public bool isAbilityCooldown = false;
    public int manaConsumption;
    public float currentAbilityCooldown;
    public int levelRequire;
    public Sprite icon;
    public virtual void Start()
    {
        isAbilityCooldown = false;
        
    }
 
    public virtual void Update()
    {

    }
    public virtual void Restart()
    {

    }
    public abstract void ActivateSkill();
    public virtual void StartSelectTarget()
    {
       
    }

}
