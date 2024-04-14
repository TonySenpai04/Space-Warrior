using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillAbility skillAbility;
    public static SkillManager instance;
    private void Start()
    {
        instance = this;
    }
    public void Restart()
    {
        skillAbility.RestartAllAbilities();
        
    }

}
