using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthText;

    [Space]
    [Header("Mana")]
    [SerializeField] private Slider manaSlider;
    [SerializeField] private Text manaText;

    [Space]
    [Header("Exp")]
    [SerializeField] private Slider expSlider;
    [SerializeField] private Text expText;
    [SerializeField] private Text leveText;
    void Start()
    {
        SetMaxValue(healthSlider,CharacterStats.instance.health.GetHealth());
        SetValue(healthSlider, CharacterStats.instance.health.GetHealth());
        SetTextUI(healthSlider, healthText);


        SetMaxValue(manaSlider, CharacterStats.instance.mana.GetMana());
        SetValue(manaSlider, CharacterStats.instance.mana.GetMana());
        SetTextUI(manaSlider, manaText);

        SetMaxValue(expSlider, CharacterStats.instance.level.GetExperience() );
        SetValue(expSlider, CharacterStats.instance.level.GetExperience());
        SetTextUI(expSlider, expText);
        leveText.text = CharacterStats.instance.level.GetLevel().ToString();
    }

    void Update()
    {
        UpdateUI();
    }
    public void SetTextUI(Slider slider,Text text)
    {
        text.text = slider.value + "/" + slider.maxValue;
    }
    public void SetMaxValue(Slider slider,float value)
    {
        slider.maxValue = value;
    }
    public void SetValue(Slider slider, float value)
    {
        slider.value = value;
    }
    public void UpdateUI()
    {
        SetMaxValue(healthSlider, CharacterStats.instance.health.GetHealth());
        SetValue(healthSlider, CharacterStats.instance.health.GetCurrentHealth());
        SetTextUI(healthSlider, healthText);

        SetMaxValue(manaSlider, CharacterStats.instance.mana.GetMana());
        SetValue(manaSlider, CharacterStats.instance.mana.GetCurrentMana());
        SetTextUI(manaSlider, manaText);

        SetMaxValue(expSlider, CharacterStats.instance.level.GetExperience());
        SetValue(expSlider, CharacterStats.instance.level.GetCurrentExp());
        SetTextUI(expSlider, expText);
        leveText.text = CharacterStats.instance.level.GetLevel().ToString();

    }
}
