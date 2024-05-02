using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private int selectedCharacterIndex=0;
    [SerializeField] private CharacterAvatar avatar;
    [SerializeField] private ChacracterData characterData;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private List<CharacterButton> characterButtons;
    [SerializeField] private GameObject charcterSelection;
    [SerializeField] private Button nextPageBtn;
    [SerializeField] private GameObject weaponSelection;
    [SerializeField] private GameObject tipObject;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        InitializeCharacterButtons();
        SetButtonListeners();
    }

    private void InitializeCharacterButtons()
    {
        CharacterButton[] characterButtons = GetComponentsInChildren<CharacterButton>();
        for (int i = 0; i < characterButtons.Length; i++)
        {
            this.characterButtons.Add(characterButtons[i]);
            this.characterButtons[i].SetIndex(i);
        }
    }

    private void SetButtonListeners()
    {
        nextPageBtn.onClick.AddListener(NextPage);
    }
    public void SetCharacterIndex(int index)
    {
        selectedCharacterIndex = index;
    }
    public void SetCharacterData(ChacracterData characterData)
    {
        this.characterData = characterData;
    }
    // Phương thức được gọi khi nhấn nút "Select"
    public void SelectCharacter()
    {
        //CharacterData selectedCharacterData = GetCharacterData(selectedCharacterIndex);
        //characterStats.SetData(selectedCharacterData);
        //avatar.SwitchCharacter(selectedCharacterIndex);
        characterStats.SetData(this.characterData);
        avatar.SetCharacter(selectedCharacterIndex);
    }

    public void NextPage()
    {
        if(characterData != null)
        {
            this.weaponSelection.SetActive(true);
            this.charcterSelection.SetActive(false);
            SelectCharacter();
        }
        else
        {
            GameObject  tipObjectIns= Instantiate(tipObject, canvas.transform);
            tipObjectIns.GetComponentInChildren<Text>().text = "PLEASE CHOOSE A CHARACTER!";
            Destroy(tipObjectIns, 1f);
        }
    }

}
