using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
    public string petName;
    public bool isUnlock;
    public int level;
    public string description;
    public virtual void Start()
    {

    }
    public virtual string GetSkillDescription()
    {
        return description;
    }
    public virtual void ActivateSkill()
    {

    }
    public virtual void Upgrade()
    {

    }
}
