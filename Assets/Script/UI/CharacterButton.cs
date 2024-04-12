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

    private void Start()
    {
        btnSelectChracter=GetComponent<Button>();
        btnSelectChracter.onClick.AddListener(SelectCharacter);
        characterSelection=GetComponentInParent<CharacterSelection>();
    }

    public void SelectCharacter()
    {
        characterSelection.SetCharacterIndex(characterIndex);
        characterSelection.SetCharacterData(this.chacracterData);
    }
    public void SetIndex(int index)
    {
        this.characterIndex = index;
    }
}
