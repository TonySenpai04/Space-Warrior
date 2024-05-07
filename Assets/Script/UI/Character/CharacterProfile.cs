using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterProfile : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField] private GameObject profile;
    [SerializeField] private Text profileTxt;
    [SerializeField] private Image characterAvt;
    [SerializeField] private Image characterAvtProfile;

    public void OnPointerClick(PointerEventData eventData)
    {
        profileTxt.text = " HEALTH : " + CharacterStats.instance.health.GetHealth() + "\n MANA : " + CharacterStats.instance.mana.GetMana()
            + "\n DAMAGE: "
            + CharacterStats.instance.damage.GetDam() + "\n CRIT RATE:" + CharacterStats.instance.damage.GetCritRate()
            +"\n LEVEL: "+ CharacterStats.instance.level.GetLevel();
        characterAvtProfile.sprite = characterAvt.sprite;
        profile.gameObject.SetActive(true);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        profileTxt.text = " HEALTH : " + CharacterStats.instance.health.GetHealth() + "\n MANA : " + CharacterStats.instance.mana.GetMana()
           + "\n DAMAGE: "
           + CharacterStats.instance.damage.GetDam() + "\n CRIT RATE:" + CharacterStats.instance.damage.GetCritRate()
           + "\n LEVEL: " + CharacterStats.instance.level.GetLevel();
        characterAvtProfile.sprite = characterAvt.sprite;
        profile.gameObject.SetActive(true);
    }

  
}
