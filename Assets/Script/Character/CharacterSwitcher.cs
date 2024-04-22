using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Character Data")]
    [SerializeField] private List<CharacterProfile> characters;
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private CharacterProfile currentCharacterProfile;

    [Space]
    [Header("UI Elements")]
    [SerializeField] private Image characterIcon;
    [SerializeField] private Button switchLeftButton;
    [SerializeField] private Button switchRightButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Image lockImage;

    [Space]
    [Header("UI Atribute")]
    [SerializeField] private Text characterNametxt;
    [SerializeField] private Text characterLeveltxt;
    [SerializeField] private Text characterHealthText;
    [SerializeField] private Text characterManaText;
    [SerializeField] private Text characterDamText;
    [SerializeField] private Text characterCritText;


    [Serializable]
    public class CharacterProfile
    {
        public ChacracterData chacracterData;
        public Sprite characterAvt;

    }
    private void Start()
    {
        if (characters.Count > 0)
        {
            currentCharacterProfile = characters[currentIndex];
            UpdateCharacter();
            switchLeftButton.onClick.AddListener(SwitchCharacterLeft);
            switchRightButton.onClick.AddListener(SwitchCharacterRight);
            upgradeButton.onClick.AddListener(UpgradeCharacter);
        }
        else
        {
            Debug.LogError("Không có nhân vật trong danh sách.");
        }
    }

    private void SwitchCharacterLeft()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = characters.Count - 1;
        }
        currentCharacterProfile = characters[currentIndex];
        UpdateCharacter();
    }

    private void SwitchCharacterRight()
    {
        currentIndex++;
        if (currentIndex >= characters.Count)
        {
            currentIndex = 0;
        }
        currentCharacterProfile = characters[currentIndex];
        UpdateCharacter();
    }

    private void UpgradeCharacter()
    {
        Debug.Log("Nâng cấp nhân vật " + currentCharacterProfile.chacracterData.name);
    }

    private void UpdateCharacter()
    {

        characterIcon.sprite = currentCharacterProfile.characterAvt;
        if (!currentCharacterProfile.chacracterData.isUnlock)
        {
            lockImage.enabled= true;
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            lockImage.enabled = false;
            upgradeButton.gameObject.SetActive(true);
        }
        characterNametxt.text = currentCharacterProfile.chacracterData.name;
        characterLeveltxt.text =  "Lv."+currentCharacterProfile.chacracterData.level.ToString();
        characterHealthText.text =  currentCharacterProfile.chacracterData.health.ToString();
        characterManaText.text =  currentCharacterProfile.chacracterData.mana.ToString();
        characterDamText.text =  currentCharacterProfile.chacracterData.damage.ToString();
        characterCritText.text = currentCharacterProfile.chacracterData.critRate.ToString();
    }
}
