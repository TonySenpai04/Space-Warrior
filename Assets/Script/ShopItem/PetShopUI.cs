using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PetShopUI : MonoBehaviour
{
    [SerializeField] private Text petNameTxt;
    [SerializeField] private Image petIcon;
    [SerializeField] private ShopItem petItem;
    [SerializeField] private Text descriptionTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Button buyBtn;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;
    public void Start()
    {
        petItem = GetComponent<ShopItem>();
        SetPetInfo(petItem);
    }

    private void SetPetInfo(ShopItem item)
    {
        IPetShop pet = (IPetShop)item;
        buyBtn = GetComponentInChildren<Button>();
        priceTxt = buyBtn.GetComponentInChildren<Text>();
        if (pet.GetPet().isUnlock)
        {
            priceTxt.text = "Already Owned";
            foreach (RectTransform child in buyBtn.GetComponent<RectTransform>())
            {
                Image image = child.GetComponent<Image>();
                if (image != null && image != buyBtn.GetComponent<Image>())
                {
                    image.enabled = false;
                }
            }
        }
        else
        {
            buyBtn.onClick.AddListener(Buy);
            priceTxt.text = item.GetPrice().ToString();
        }

        petNameTxt.text = pet.GetPetName();
        petIcon.sprite = item.itemSprite;
        descriptionTxt.text = item.GetInfo();
    }
    public void Buy()
    {

        petItem.Buy();
        if (petItem.isBuy)
        {
            buyBtn.GetComponentInChildren<Text>().text = "Already Owned";
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "SUCCESSFULLY PURCHASE";
            Destroy(tipObjectIns, 1f);
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
        else
        {
            CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == petItem.priceType);
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "YOU STILL LACK " + (int)(petItem.price - currency.quantity) + " " +
                petItem.priceType.ToString().ToUpper() + " TO BUY";
            Destroy(tipObjectIns, 1f);
        }


    }
}
