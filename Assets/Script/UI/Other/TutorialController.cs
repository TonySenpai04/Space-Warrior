using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private List<Image> tutorialImages;  
    [SerializeField] private Button backButton;            
    [SerializeField] private Button nextButton;            
    private int currentImageIndex = 0;                     

    void Start()
    {
        if (tutorialImages != null && tutorialImages.Count > 0)
        {
            for (int i = 0; i < tutorialImages.Count; i++)
            {
                tutorialImages[i].gameObject.SetActive(i == 0);
            }

            UpdateButtonVisibility();
        }
        backButton.onClick.AddListener(ShowPreviousImage);
        nextButton.onClick.AddListener(ShowNextImage);
    }

    void UpdateButtonVisibility()
    {
        backButton.gameObject.SetActive(currentImageIndex > 0);
        nextButton.gameObject.SetActive(currentImageIndex < tutorialImages.Count - 1);
    }

    public void ShowNextImage()
    {
        if (currentImageIndex < tutorialImages.Count - 1)
        {
            tutorialImages[currentImageIndex].gameObject.SetActive(false);
            currentImageIndex++;
            tutorialImages[currentImageIndex].gameObject.SetActive(true);
            UpdateButtonVisibility();
        }
    }

    public void ShowPreviousImage()
    {
        if (currentImageIndex > 0)
        {
            tutorialImages[currentImageIndex].gameObject.SetActive(false);
            currentImageIndex--;
            tutorialImages[currentImageIndex].gameObject.SetActive(true);
            UpdateButtonVisibility();
        }
    }
}
