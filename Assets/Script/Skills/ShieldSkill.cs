using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : SkillBase
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private bool isActive=false;
    [SerializeField] private float effectiveTime = 3f;
    [SerializeField] private Transform player;
    public override void ActivateSkill()
    {
        isActive=true;
        CharacterStats.instance.mana.UseMana(manaConsumption);
    }
    public override void Update()
    {
        shieldObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, player.transform.position.z);
        if (isActive)
        {

            //shieldObject.gameObject.transform.position =new Vector3( player.transform.position.x, player.transform.position.y+0.8f, player.transform.position.z);
            shieldObject.transform.parent= player.transform;
            shieldObject.SetActive(true);
            effectiveTime -= Time.deltaTime;
            if (effectiveTime <= 0)
            {
                isActive = false;
                effectiveTime = 3f;
               
            }
        }
        else
        {
            shieldObject.SetActive(false);
        }
        
    }
    public override void Restart()
    {
        isActive=false;
        effectiveTime = 3f;
        shieldObject.SetActive(false);
        isAbilityCooldown = false;
        currentAbilityCooldown = 0f;


    }
    //IEnumerator ShowShield()
    //{
    //    shieldObject.SetActive(true);
    //    yield return new WaitForSeconds(3f);
    //    shieldObject.SetActive(false);
    //}

    public override void Start()
    {
        base.Start();
        
        shieldObject = Instantiate(shieldPrefab);
        shieldObject.SetActive(false); 
    }
}
