using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    [SerializeField] private List<Pet> pets;
    [SerializeField] private int currentPetIndex;
    private void Start()
    {
        ShowCurrentPet();
    }
    private void FixedUpdate()
    {
        ShowCurrentPet();
    }

    private void ShowCurrentPet()
    {
        for (int i = 0; i < pets.Count; i++)
        {
            if (i == currentPetIndex && pets[i].isUnlock)
            {
                pets[i].gameObject.SetActive(true); 
            }
            else
            {
                pets[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChangePet(int newIndex)
    {
        
        if (newIndex >= 0 && newIndex < pets.Count)
        {
            currentPetIndex = newIndex;
            ShowCurrentPet(); 
        }
        else
        {
            Debug.LogWarning("Invalid pet index!");
        }
    }

 
}
