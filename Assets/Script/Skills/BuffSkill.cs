using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : SkillBase
{
    [SerializeField]private CharacterStats characterStats;
    [SerializeField] private bool isActive;
    [SerializeField] private float originalDamage;
    public override void Start()
    {
        base.Start();
    }
    public override void ActivateSkill()
    {
        isActive=true;
        StartCoroutine(ApplyBuff());
    }

    IEnumerator ApplyBuff()
    {

        if (characterStats != null && isActive)
        {
  
             originalDamage = characterStats.damage.GetDam();
            Debug.Log(originalDamage);

            // Tăng 20% các chỉ số
            //characterStats.MaxHealth *= 1.2f;
            //characterStats.MaxMana *= 1.2f;
            characterStats.damage.SetDam(characterStats.damage.GetDam()*1.2f) ;
            Debug.Log(characterStats.damage.GetDam());
            // Đợi 4 giây
            yield return new WaitForSeconds(4f);

            // Reset các chỉ số về giá trị ban đầu
            // characterStats.MaxHealth = originalHealth;
            // characterStats.MaxMana = originalMana;
            characterStats.damage.SetDam(originalDamage);
            isActive=false;
            Debug.Log(characterStats.damage.GetDam());

        }
        else
        {
            Debug.Log("CharacterStats component not found on the GameObject.");
        }
    }
    public override void Restart()
    {
        isActive = false;
        isAbilityCooldown = false;
    }
    
}
