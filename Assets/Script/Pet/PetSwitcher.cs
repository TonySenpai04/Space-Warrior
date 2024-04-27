using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSwitcheer : MonoBehaviour
{
    [Header("Character Data")]
    [SerializeField] private List<PetProfile> pets;
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private PetProfile currentPetProfile;
    [SerializeField] private PetManager petManager;

    [Space]
    [Header("UI Elements")]
    [SerializeField] private Image petIcon;
    [SerializeField] private Button switchLeftButton;
    [SerializeField] private Button switchRightButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Image lockImage;
    [SerializeField] private Text soulRequiredText;

    [Space]
    [Header("UI Atribute")]
    [SerializeField] private Text petNametxt;
    [SerializeField] private Text petLeveltxt;
    [SerializeField] private Text descriptionText;


    [Serializable]
    public class PetProfile

    {
        public Pet pet;
        public Sprite characterAvt;
  

    }

    [Obsolete]
    private void Start()
    {
        if (pets.Count > 0)
        {
            currentPetProfile = pets[currentIndex];
            UpdatePet();
            switchLeftButton.onClick.AddListener(SwitchPetLeft);
            switchRightButton.onClick.AddListener(SwitchPetRight);
            upgradeButton.onClick.AddListener(UpgradePet);
            useButton.onClick.AddListener(UsePet);
        }
        else
        {
            Debug.LogError("Không có pet trong danh sách.");
        }
    }
    public void UsePet()
    {
        if (!currentPetProfile.pet.isUse)
        {

            currentPetProfile.pet.isUse = true;
            foreach (var pet in pets)
            {
                if (pet != currentPetProfile)
                {
                    pet.pet.isUse = false;
                }
            }
            useButton.GetComponentInChildren<Text>().text = "UNUSE";
        }
        else
        {
            currentPetProfile.pet.isUse = false;
            useButton.GetComponentInChildren<Text>().text = "USE";
        }

        petManager.ChangePetByPet(currentPetProfile.pet);
    }
    private void SwitchPetLeft()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = pets.Count - 1;
        }
        currentPetProfile = pets[currentIndex];
        UpdatePet();
    }

    private void SwitchPetRight()
    {
        currentIndex++;
        if (currentIndex >= pets.Count)
        {
            currentIndex = 0;
        }
        currentPetProfile = pets[currentIndex];
        UpdatePet();
    }

    [Obsolete]
    private void UpgradePet()
    {
        int currentLevel = currentPetProfile.pet.level;
        int requiredSoul = 50 * currentLevel;
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
        Debug.Log(randomUpgradeSuccessRate);
        if (currentLevel < 7 &&
            CurrencyManager.instance.GetCurrencyQuantity(CurrencyManager.CurrencyType.Soul) >= requiredSoul)
        {
            CurrencyManager.instance.RemoveItem(CurrencyManager.CurrencyType.Soul, requiredSoul);
            if (randomUpgradeSuccessRate <= upgradeSuccessRate)
            {
                currentPetProfile.pet.level++;
                int newLevel = currentPetProfile.pet.level;
                currentPetProfile.pet.Upgrade();

                Debug.Log("Pet upgraded successfully to level " + currentPetProfile.pet.level);
            }
            else
            {
                Debug.Log("Pet upgrade failded");
            }
            UpdatePet();

            
        }
        else
        {
            Debug.Log("Not enough resources or already at maximum level to upgrade character!");
        }
    }


    private void UpdatePet()
    {

        petIcon.sprite = currentPetProfile.characterAvt;
        if (!currentPetProfile.pet.isUnlock)
        {
            lockImage.enabled = true;
            upgradeButton.gameObject.SetActive(false);
            useButton.gameObject.SetActive(false );
        }
        else
        {
           
            lockImage.enabled = false;
            useButton.gameObject.SetActive(true);
            if (!currentPetProfile.pet.isUse)
            {

                useButton.GetComponentInChildren<Text>().text = "USE";
            }
            else
            {
                useButton.GetComponentInChildren<Text>().text = "UNUSE";
            }
            int currentLevel = currentPetProfile.pet.level;
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
                upgradeButton.GetComponentInChildren<Text>().text = "UPGRADE(Success Rate:" + upgradeSuccessRate+"%)";
                int requiredSoul = 50 * currentLevel;
                soulRequiredText.text = requiredSoul.ToString();
                soulRequiredText.gameObject.SetActive(true);
            }
            else
            {
                upgradeButton.GetComponentInChildren<Text>().text = "MAX";
                soulRequiredText.gameObject.SetActive(false);
            }
            upgradeButton.gameObject.SetActive(true);
        }
        petNametxt.text = currentPetProfile.pet.petName;
        petLeveltxt.text = "Lv." + currentPetProfile.pet.level.ToString();
        descriptionText.text = currentPetProfile.pet.GetSkillDescription();

    }
}
