using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleMP : Bottle
{
    public CharacterStats characterStats;
    public Text text;
    public override  void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(RestoreMana);
        text.text = count.ToString();
    }
    public void RestoreMana()
    {
        if (count > 0)
        {
            characterStats.mana.RestoreMana((int)characterStats.mana.GetMana() / 10);
            count--;
            text.text = count.ToString();
        }

    }
}
