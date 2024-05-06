using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BottleItemShopUI : MonoBehaviour
{
    [SerializeField] private Text bottleNameTxt;
    [SerializeField] private Image bottleIcon;
    [SerializeField] private ShopItem bottletem;
    [SerializeField] private Text descriptionTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Button buyBtn;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;
    public void Start()
    {
        bottletem = GetComponent<ShopItem>();
        SetBottleInfo(bottletem);
    }

    private void SetBottleInfo(ShopItem item)
    {
        buyBtn = GetComponentInChildren<Button>();
        buyBtn.onClick.AddListener(Buy);
        priceTxt.text = item.GetPrice().ToString();
        bottleNameTxt.text = bottletem.itemName.ToUpper();
        bottleIcon.sprite = item.itemSprite;
        descriptionTxt.text = item.GetInfo();
    }
    public void Buy()
    {

        
        CurrencyManager.Currency currency = CurrencyManager.instance.Inventory.Find(item => item.type == bottletem.priceType);
        if (bottletem.GetPrice()<= currency.quantity)
        {
            bottletem.Buy();
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "SUCCESSFULLY PURCHASE" ;
            Destroy(tipObjectIns, 1f);
        }
        else
        {
            GameObject tipObjectIns = Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "YOU STILL LACK " + (int)(bottletem.price - currency.quantity) + " " +
                bottletem.priceType.ToString().ToUpper() + " TO BUY";
            Destroy(tipObjectIns, 1f);
        }


    }
}
