using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private Text characterNameText;
    [SerializeField] private Button btnCheck;
    private void Start()
    {
        btnCheck.onClick.AddListener(CheckName);
    }
    public void CheckName()
    {
        UpdateCharacterName();
    }
    public void UpdateCharacterName()
    {
        string newName = nameInputField.text;

        if (!string.IsNullOrEmpty(newName))
        {
            characterNameText.text = newName;
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Character name cannot be empty!");
        }
    }
}
