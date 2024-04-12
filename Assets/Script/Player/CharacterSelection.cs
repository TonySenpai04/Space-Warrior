using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private int selectedCharacterIndex=0;
    [SerializeField] private CharacterAvatar avatar;
    [SerializeField] private ChacracterData characterData;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private List<CharacterButton> characterButtons;

    private void Start()
    {
        CharacterButton[] CharacterButtons=GetComponentsInChildren<CharacterButton>();
        for(int i=0; i< CharacterButtons.Length; i++)
        {
            this.characterButtons.Add(CharacterButtons[i]);
            this.characterButtons[i].SetIndex(i);
        }
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

    //private CharacterData GetCharacterData(int index)
    //{
    //    // Thực hiện logic để lấy dữ liệu của nhân vật từ nguồn dữ liệu của bạn
    //    // Ví dụ:
    //     return characterDataArray[index];
    //}

}
