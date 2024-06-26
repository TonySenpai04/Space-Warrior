using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class    SkillAbility : MonoBehaviour,IObserver
{
    public static SkillAbility instance;
    [Header("Skill1")]
    public Image abilityImage1;
    public TextMeshProUGUI abilityText1;
   // public KeyCode ability1Key;
    public float ability1Cooldown;
   // private bool isAbility1Cooldown = false;
    //public float currentAbility1Cooldown;
    public SkillBase skill1;
    [Header("Skill2")]
    public Image abilityImage2;
    public TextMeshProUGUI abilityText2;
   // public KeyCode ability2Key;
    public float ability2Cooldown;
  //  private bool isAbility2Cooldown = false;
   // public float currentAbility2Cooldown;
    public SkillBase skill2;
    [Header("Skill3")]
    public Image abilityImage3;
    public TextMeshProUGUI abilityText3;
   // public KeyCode ability3Key;
    public float ability3Cooldown;
    //  private bool isAbility3Cooldown = false;
    // public float currentAbility3Cooldown;
    public SkillBase skill3;

    void Start()
    {
        instance = this;
        abilityImage1.fillAmount = 0;
       // abilityImage2.fillAmount = 0;
       // abilityImage3.fillAmount = 0;

        abilityText1.text = "";
       // abilityText2.text = "";
       // abilityText3.text = "";

        ability2Cooldown = skill2.countdown;
        ability1Cooldown = skill1.countdown;
        ability3Cooldown= skill3.countdown;

        UpdateSkill();

    }
    public void UpdateSkillAvailability(SkillBase skill, Image abilityImage, TextMeshProUGUI abilityText)
    {
        if (skill.levelRequire > CharacterStats.instance.level.GetLevel())
        {
            abilityImage.fillAmount = 1;
            abilityText.text = "Unlock at level " + skill.levelRequire;
        }
        else
        {
            abilityImage.fillAmount = 0;
            abilityText.text = "";
        }
    }
    public void UpdateSkill()
    {
        UpdateSkillAvailability(skill2, abilityImage2, abilityText2);
        UpdateSkillAvailability(skill3, abilityImage3, abilityText3);
    }



    void Update()
    {


        AbilityCooldown(ref skill1.currentAbilityCooldown, ability1Cooldown, ref skill1.isAbilityCooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref skill2.currentAbilityCooldown, ability2Cooldown, ref skill2.isAbilityCooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref skill3.currentAbilityCooldown, ability3Cooldown, ref skill3.isAbilityCooldown, abilityImage3, abilityText3);
       
    }
    public void Ability1Input()
    {
        if (!skill1.isAbilityCooldown)
        {
            skill1.ActivateSkill();
            skill1.StartSelectTarget();
            skill1.isAbilityCooldown = true;
            skill1.currentAbilityCooldown = ability1Cooldown;
            
        }
    }
    public void Ability2Input()
    {
        if (!skill2.isAbilityCooldown && skill2.levelRequire <= CharacterStats.instance.level.GetLevel())
        {
            Debug.Log(skill2.levelRequire >= CharacterStats.instance.level.GetLevel());
            skill2.isAbilityCooldown = true;
            skill2.currentAbilityCooldown = ability2Cooldown;
            skill2.ActivateSkill();


        }
    }
    public void Ability3Input()
    {
        if ( !skill3.isAbilityCooldown&& skill3.levelRequire <= CharacterStats.instance.level.GetLevel())
        {
            skill3.isAbilityCooldown = true;
            skill3.currentAbilityCooldown = ability3Cooldown;
            skill3.ActivateSkill();

            
          
        }
    }
    public void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;
                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = currentCooldown.ToString("N1");
                }
            }

        }
    }
    public void RestartAbility1()
    {
        skill1.currentAbilityCooldown = 0f;
        skill1.isAbilityCooldown = false;
        skill1.Restart();
        ResetUI(abilityImage1, abilityText1);
    }

    public void RestartAbility2()
    {
        skill2.isAbilityCooldown = false;
        skill2.currentAbilityCooldown = 0f;
        skill2.Restart();
        ResetUI(abilityImage2, abilityText2);
    }

    public void RestartAbility3()
    {
        skill3.isAbilityCooldown = false;
        skill3.currentAbilityCooldown = 0f;
        skill3.Restart();
        ResetUI(abilityImage3, abilityText3);
    }

    public void RestartAllAbilities()
    {
        RestartAbility1();
        RestartAbility2();
        RestartAbility3();
        UpdateSkill(); 
    }


    private void ResetUI(Image image, TextMeshProUGUI text)
    {
        if (image != null)
        {
            image.fillAmount = 0f;
        }
        if (text != null)
        {
            text.text = "";
        }
    }

    public void UpdateObserver()
    {
        RestartAllAbilities();
    }
}