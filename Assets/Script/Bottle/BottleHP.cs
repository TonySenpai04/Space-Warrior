using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleHP : MonoBehaviour
{
    public int count;
    public CharacterStats characterStats;
    public Text text;
    private void Start()
    {
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
