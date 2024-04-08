using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class SkillBase : MonoBehaviour
{
    public float countdown;
    public bool isAbilityCooldown = false;
    public int manaConsumption;
    public virtual void Start()
    {
        
    }
    public virtual void Update()
    {

    }
    public abstract void ActivateSkill();
    public virtual void StartSelectTarget()
    {
       
    }

}
