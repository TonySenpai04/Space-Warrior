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

    private void Start()
    {
        CharacterButton[] CharacterButtons=GetComponentsInChildren<CharacterButton>();
        for(int i=0; i< CharacterButtons.Length; i++)
        {
            this.characterButtons.Add(CharacterButtons[i]);
            this.characterButtons[i].SetIndex(i);
        }
        characterButtons[0].SelectCharacter();
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
    }

}
