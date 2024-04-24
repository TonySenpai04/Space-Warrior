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
    [SerializeField] private Text coinRequiredText;
    [SerializeField] private Text gemRequiredText;

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

    [Obsolete]
    private void UpgradeCharacter()
    {
        int currentLevel = currentCharacterProfile.chacracterData.level;
        int requiredCoin = 50 * currentLevel;
        int requiredGem = 10 * currentLevel;
        float upgradeSuccessRate;
        switch (currentLevel)
        {
            case 1:
                upgradeSuccessRate = 80;
                break;
            case 2:
                upgradeSuccessRate = 60;
                break;
            case 3:
                upgradeSuccessRate = 40;
                break;
            case 4:
                upgradeSuccessRate = 20;
                break;
            case 5:
                upgradeSuccessRate = 10;
                break;
            default:
                upgradeSuccessRate = 5;
                break;
        }
        float randomUpgradeSuccessRate = UnityEngine.Random.RandomRange(0, 100);
        if (currentLevel < 7 &&
            CurrencyManager.instance.GetCurrencyQuantity(CurrencyManager.CurrencyType.Coin) >= requiredCoin &&
            CurrencyManager.instance.GetCurrencyQuantity(CurrencyManager.CurrencyType.Gem) >= requiredGem)
        {
            CurrencyManager.instance.RemoveItem(CurrencyManager.CurrencyType.Coin, requiredCoin);
            CurrencyManager.instance.RemoveItem(CurrencyManager.CurrencyType.Gem, requiredGem);
            if (randomUpgradeSuccessRate <= upgradeSuccessRate)
            {
                currentCharacterProfile.chacracterData.level++;
                int newLevel = currentCharacterProfile.chacracterData.level;

                currentCharacterProfile.chacracterData.UpgradeCharacter(newLevel);

                Debug.Log("Character upgraded successfully to level " + currentCharacterProfile.chacracterData.level);
            }
            else
            {
                Debug.Log("Charcter upgrade failded");
            }

            UpdateCharacter();
        }
        else
        {
            Debug.Log("Not enough resources or already at maximum level to upgrade character!");
        }
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
            int currentLevel = currentCharacterProfile.chacracterData.level;
            float upgradeSuccessRate;
            switch (currentLevel)
            {
                case 1:
                    upgradeSuccessRate = 80;
                    break;
                case 2:
                    upgradeSuccessRate = 60;
                    break;
                case 3:
                    upgradeSuccessRate = 40;
                    break;
                case 4:
                    upgradeSuccessRate = 20;
                    break;
                case 5:
                    upgradeSuccessRate = 10;
                    break;
                default:
                    upgradeSuccessRate = 5;
                    break;
            }
            if (currentLevel < 7)
            {
                upgradeButton.GetComponentInChildren<Text>().text = "UPGRADE(Success Rate:" + upgradeSuccessRate + "%)"; ;
                int requiredCoin = 50 * currentLevel;
                int requiredGem = 10 * currentLevel;
                coinRequiredText.text = requiredCoin.ToString();
                gemRequiredText.text = requiredGem.ToString();
                coinRequiredText.gameObject.SetActive(true);
                gemRequiredText.gameObject.SetActive(true);
            }
            else
            {
                upgradeButton.GetComponentInChildren<Text>().text = "MAX";
                coinRequiredText.gameObject.SetActive(false);
                gemRequiredText.gameObject.SetActive(false);
            }
            upgradeButton.gameObject.SetActive(true);
        }
        characterNametxt.text = currentCharacterProfile.chacracterData.name;
        characterLeveltxt.text =  "Lv."+currentCharacterProfile.chacracterData.level.ToString();
        characterHealthText.text = Mathf.RoundToInt(currentCharacterProfile.chacracterData.health).ToString();
        characterManaText.text = Mathf.RoundToInt(currentCharacterProfile.chacracterData.mana).ToString();
        characterDamText.text = Mathf.RoundToInt(currentCharacterProfile.chacracterData.damage).ToString();
        characterCritText.text = Mathf.RoundToInt(currentCharacterProfile.chacracterData.critRate).ToString();

    }
}
