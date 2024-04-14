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
    public KeyCode ability1Key;
    public float ability1Cooldown;
   // private bool isAbility1Cooldown = false;
    //public float currentAbility1Cooldown;
    public SkillBase skill1;
    [Header("Skill2")]
    public Image abilityImage2;
    public TextMeshProUGUI abilityText2;
    public KeyCode ability2Key;
    public float ability2Cooldown = 8;
    private bool isAbility2Cooldown = false;
    public float currentAbility2Cooldown;
    [Header("Skill3")]
    public Image abilityImage3;
    public TextMeshProUGUI abilityText3;
    public KeyCode ability3Key;
    public float ability3Cooldown = 12;
    private bool isAbility3Cooldown = false;
    public float currentAbility3Cooldown;
    
    void Start()
    {
        instance = this;
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        abilityText1.text = "";
        abilityText2.text = "";
        abilityText3.text = "";

        ability1Cooldown = skill1.countdown;


    }
    void Update()
    {
        

        Ability1Input();
        Ability2Input();
        Ability3Input();
        AbilityCooldown(ref skill1.currentAbilityCooldown, ability1Cooldown, ref skill1.isAbilityCooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, abilityText3);
       
    }
    private void Ability1Input()
    {
        if ((Input.GetKey(ability1Key) && !skill1.isAbilityCooldown))
        {
            skill1.StartSelectTarget();
            skill1.ActivateSkill();
            skill1.isAbilityCooldown = true;
            skill1.currentAbilityCooldown = ability1Cooldown;
            
        }
    }
    private void Ability2Input()
    {
        if ((Input.GetKey(ability2Key) && !isAbility2Cooldown))
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
      
        }
    }
    private void Ability3Input()
    {
        if ((Input.GetKey(ability3Key) && !isAbility3Cooldown))
        {
            isAbility3Cooldown = true;
            
          
        }
    }
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
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
        isAbility2Cooldown = false;
        currentAbility2Cooldown = 0f;
        ResetUI(abilityImage2, abilityText2);
    }

    public void RestartAbility3()
    {
        isAbility3Cooldown = false;
        currentAbility3Cooldown = 0f;
        ResetUI(abilityImage3, abilityText3);
    }

    public void RestartAllAbilities()
    {
        RestartAbility1();
        RestartAbility2();
        RestartAbility3();
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