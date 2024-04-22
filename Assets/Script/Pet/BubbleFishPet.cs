using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFishPet : Pet
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private bool isSkillActive = false;
    [SerializeField] private float timer = 0f;
    [SerializeField] private  float shieldInterval = 2f;
    [SerializeField] private  float shieldDuration = 15f;
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private float effectiveTime;

    public override void Start()
    {
        effectiveTime = shieldDuration;
        shieldObject = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);
        shieldObject.transform.position= new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, player.transform.position.z);
        shieldObject.transform.parent = player.transform;
        shieldObject.SetActive(false);
    }


    private void Update()
    {
        shieldObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, player.transform.position.z);
        if (isSkillActive)
        {
            timer += Time.deltaTime;
            if (timer >= shieldInterval)
            {
                shieldObject.SetActive(true);


                timer = 0f;
            }
            if (shieldObject.activeInHierarchy)
            {
                effectiveTime -= Time.deltaTime;
                if (effectiveTime <= 0)
                {

                    effectiveTime = shieldDuration;
                    shieldObject.SetActive(false);

                }
            }
           
        }
        else
        {
            shieldObject.SetActive(false);
            effectiveTime = shieldDuration; 
        }
    }



    public override void ActivateSkill()
    {
        isSkillActive = true;
    }
}
