using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int slot;
    [SerializeField] private int weaponIndex;
    [SerializeField] public Image weaponImage;
    [SerializeField] public GenericWeapon weapon;
    [SerializeField] private Text weaponName;
    [SerializeField] private Button weaponButton;
    [SerializeField] private GameObject gunInfoPanel;
    [SerializeField] private Text gunInfoPanelText;
    [SerializeField] private RectTransform buttonRectTransform;
    private RectTransform scrollViewRectTransform;



    void Start()
    {
        InitializeComponents();
        SetupButtonListener();
        DisableRaycastTarget();
        gunInfoPanel.SetActive(false);
        buttonRectTransform = GetComponent<RectTransform>();
        scrollViewRectTransform = GetComponentInParent<ScrollRect>().GetComponent<RectTransform>();
    }

    void InitializeComponents()
    {
        weaponButton = GetComponent<Button>();
      
    }

    void SetupButtonListener()
    {
        weaponButton.onClick.AddListener(SelectedWeapon);
    }

    void DisableRaycastTarget()
    {
        weaponImage.raycastTarget = false;
    }

    private void SelectedWeapon()
    {
        GetComponentInParent<WeaponSelectionManager>().AddWeapon(slot, weaponIndex);
    }
    public void SetWeapon(int slot, int weaponIndex,GenericWeapon weapon)
    {
        this.slot = slot;
        this.weaponIndex = weaponIndex;
        this.weapon = weapon;
        this.weaponName.text = weapon.name;
        this.weaponImage.sprite = weapon.weaponSprite.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string ammoText = weapon.IsInfiniteAmmo ? "Infinite" : weapon.AmmoCount.ToString();
        gunInfoPanelText.text = "Damage Rate: " + weapon.DamageRate + "\nAmmo Count: " + ammoText + "\nFire Rate: " + weapon.FireRate;
        Vector3 buttonLocalPos = buttonRectTransform.localPosition;
        Vector3 panelPos = buttonLocalPos + new Vector3(buttonRectTransform.rect.width / 2f, buttonRectTransform.rect.height / 2f, 0f);
        gunInfoPanel.transform.localPosition = panelPos;
        gunInfoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gunInfoPanel.SetActive(false);
    }
}
