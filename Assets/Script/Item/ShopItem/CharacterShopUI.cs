using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopUI : MonoBehaviour
{
    [SerializeField] private Text characterNameTxt;
    [SerializeField] private Image characterIcon;
    [SerializeField] private ShopItem character;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Button buyBtn;
    public void Start()
    {
        character = GetComponent<ShopItem>();
        SetCharacterInfo(character);
    }

    private void SetCharacterInfo(ShopItem item)
    {
        buyBtn = GetComponentInChildren<Button>();
        buyBtn.onClick.AddListener(Buy);
        characterNameTxt.text = character.itemName;
        characterIcon.sprite = item.itemSprite;
        priceTxt.text = item.GetPrice().ToString();
    }
    public void Buy()
    {

        character.Buy();
        if (character.isBuy)
        {
            buyBtn.GetComponentInChildren<Text>().text = "Already Owned";
            foreach (RectTransform child in buyBtn.GetComponent<RectTransform>())
            {
                Image image = child.GetComponent<Image>();
                if (image != null && image != buyBtn.GetComponent<Image>())
                {
                    image.enabled = false;
                }
            }
            buyBtn.onClick.RemoveListener(Buy);
        }


    }
}
