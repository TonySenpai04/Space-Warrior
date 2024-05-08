using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleHP : Bottle
{
    public CharacterStats characterStats;
    public Text text;
    public override void Start()
    {
        base.Start();
        GetComponentInChildren<Button>().onClick.AddListener(Heal);
        text.text=count.ToString();
       
   
    }
    public void Heal()
    {
        if (count > 0)
        {
            characterStats.health.Heal((int)characterStats.health.GetHealth() / 10);
            count--;
            text.text = count.ToString();
        }
    }
}
