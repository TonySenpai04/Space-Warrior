using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class SkillBase : MonoBehaviour
{
    public float countdown;
    public bool isAbilityCooldown = false;
    public virtual void Start()
    {
        
    }
    public virtual void Update()
    {

    }
    public abstract void ActivateSkill();

}