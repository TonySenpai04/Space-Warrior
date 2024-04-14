using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleMP : MonoBehaviour
{
    public int count;
    public CharacterStats characterStats;
    public Text text;
    private void Start()
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
