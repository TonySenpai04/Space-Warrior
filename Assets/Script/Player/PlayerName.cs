using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private Text characterNameText;
    [SerializeField] private Button btnCheck;
    private string[] randomNames = { "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry" };
    private void Awake()
    {
        LoadPlayerName();
    }

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
            SavePlayerName();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Character name cannot be empty!");
        }
    }
    public void RandomName()
    {
        int randomIndex = Random.Range(0, randomNames.Length);
        nameInputField.text = randomNames[randomIndex];
    }
    private void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", nameInputField.text);
        PlayerPrefs.SetInt("isSavePlayerName", 1);
        PlayerPrefs.Save();
 
    }

    private void LoadPlayerName()
    {
        if (PlayerPrefs.GetInt("isSavePlayerName", 0) == 1)
        {
            string savedName = PlayerPrefs.GetString("PlayerName");
            if (!string.IsNullOrEmpty(savedName))
            {
                characterNameText.text = savedName;
                nameInputField.text = savedName;
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }

        }
    }
    private void OnApplicationQuit()
    {
        SavePlayerName();
    }
}
