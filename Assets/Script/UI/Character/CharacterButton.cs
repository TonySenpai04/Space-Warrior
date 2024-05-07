using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private Button btnSelectChracter;
    [SerializeField] private int characterIndex; 
    [SerializeField] private CharacterSelection characterSelection;
    [SerializeField] private ChacracterData chacracterData;
    [SerializeField] private GameObject lockPanel;
    [SerializeField] private Text levelTxt;
    private void Start()
    {
        InitializeButton();
        CheckCharacterUnlockStatus();
    }

    private void InitializeButton()
    {
        btnSelectChracter = GetComponent<Button>();
        btnSelectChracter.onClick.AddListener(SelectCharacter);
        characterSelection = GetComponentInParent<CharacterSelection>();
    }

    private void CheckCharacterUnlockStatus()
    {
        if (chacracterData.isUnlock)
        {
            lockPanel.gameObject.SetActive(false);
            levelTxt.text = "LV." + chacracterData.level;
        }
        else
        {
            lockPanel.gameObject.SetActive(true);
            levelTxt.text = "";
        }
    }
    private void FixedUpdate()
    {
        CheckCharacterUnlockStatus();
    }
    public void SelectCharacter()
    {
        if (chacracterData.isUnlock)
        {
            characterSelection.SetCharacterIndex(characterIndex);
            characterSelection.SetCharacterData(this.chacracterData);
        }
    }
    public void SetIndex(int index)
    {
        this.characterIndex = index;
    }
}
