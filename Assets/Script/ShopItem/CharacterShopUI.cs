using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterShopUI : MonoBehaviour ,IPointerClickHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Text characterNameTxt;
    [SerializeField] private Image characterIcon;
    [SerializeField] private ShopItem character;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Button buyBtn;
    [SerializeField] private GameObject characterInfoPanel;
    [SerializeField] private Text characterHealthText;
    [SerializeField] private Text characterManaText;
    [SerializeField] private Text characterDamText;
    [SerializeField] private Text characterCritText;
    [SerializeField] private RectTransform panelRectTransform;
    [SerializeField] private Image characterAvtInfo;
    [SerializeField] private GameObject priceUI;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;
    public void Start()
    {
        character = GetComponent<ShopItem>();
       
        panelRectTransform=GetComponent<RectTransform>();
        SetCharacterInfo(character);
    }

    private void SetCharacterInfo(ShopItem item)
    {
        buyBtn = GetComponentInChildren<Button>();
        ICharacterShop characterShop = (ICharacterShop)character;
        if (characterShop.GetChacracterData().isUnlock)
        {
            buyBtn.GetComponentInChildren<Text>().text = "Already Owned";
            priceUI.SetActive(false);

        }
        else
        {
            buyBtn.onClick.AddListener(Buy);
        }
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
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "SUCCESSFULLY PURCHASE";
            Destroy(tipObjectIns, 1f);
            priceUI.SetActive(false);
            buyBtn.onClick.RemoveListener(Buy);
        }
        else
        {
            CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == character.priceType);
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "YOU STILL LACK "+(int) (character.price-currency.quantity)+" "+
                character.priceType.ToString().ToUpper()+ " TO BUY";
            Destroy(tipObjectIns, 1f);
        }

    }

    

    public void OnPointerExit(PointerEventData eventData)
    {
        characterInfoPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ICharacterShop characterShop = (ICharacterShop)character;
        characterHealthText.text = characterShop.GetChacracterData().health.ToString();
        characterManaText.text = characterShop.GetChacracterData().mana.ToString();
        characterDamText.text = characterShop.GetChacracterData().damage.ToString();
        characterCritText.text = characterShop.GetChacracterData().critRate.ToString();
        characterAvtInfo.sprite = characterIcon.sprite;
        Vector3 buttonLocalPos = panelRectTransform.localPosition;
        Vector3 panelPos = buttonLocalPos + new Vector3(panelRectTransform.rect.width, -panelRectTransform.rect.height, 0f);
        characterInfoPanel.transform.localPosition = panelPos;
        if (characterInfoPanel.GetComponent<RectTransform>().anchoredPosition.x >= 69)
        {
            characterInfoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2,
                characterInfoPanel.GetComponent<RectTransform>().anchoredPosition.y);
        }
        characterInfoPanel.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ICharacterShop characterShop = (ICharacterShop)character;
        characterHealthText.text = characterShop.GetChacracterData().health.ToString();
        characterManaText.text = characterShop.GetChacracterData().mana.ToString();
        characterDamText.text = characterShop.GetChacracterData().damage.ToString();
        characterCritText.text = characterShop.GetChacracterData().critRate.ToString();
        characterAvtInfo.sprite = characterIcon.sprite;
        Vector3 buttonLocalPos = panelRectTransform.localPosition;
        Vector3 panelPos = buttonLocalPos + new Vector3(panelRectTransform.rect.width, -panelRectTransform.rect.height, 0f);
        characterInfoPanel.transform.localPosition = panelPos;
        if (characterInfoPanel.GetComponent<RectTransform>().anchoredPosition.x >= 69)
        {
            characterInfoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2,
                characterInfoPanel.GetComponent<RectTransform>().anchoredPosition.y);
        }
        characterInfoPanel.SetActive(true);
    }
}
