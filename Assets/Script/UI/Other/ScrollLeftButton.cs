using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLeftButton : MonoBehaviour
{
    public ScrollRect scrollView;
    public float scrollSpeed = 1f;
    public List<Toggle> toggles;
    public int currentToggleIndex = 0;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ScrollLeft);
    }

    private void ScrollLeft()
    {
        if (scrollView != null && currentToggleIndex >0)
        {
            if (currentToggleIndex != 0)
            {
                scrollView.normalizedPosition -= new Vector2(scrollSpeed, 0f);
            }
           
            UpdateToggles();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                currentToggleIndex = i;
            }
        }
    }
    private void UpdateToggles()
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                currentToggleIndex = i;
            }
        }
        if (currentToggleIndex > 0)
        {
            currentToggleIndex--;
        }
        for (int i = 0; i < toggles.Count; i++)
        {
            if (i == currentToggleIndex)
            {
                toggles[i].isOn = true;
            }
            else
            {
                toggles[i].isOn = false;
            }
        }

    }
}
