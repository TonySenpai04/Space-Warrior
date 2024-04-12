using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRightButton : MonoBehaviour
{
    public ScrollRect scrollView;
    public float scrollSpeed = 1f;
    public List<Toggle> toggles;
    private int currentToggleIndex = 0;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ScrollRight);
    }

    private void ScrollRight()
    {
        if (scrollView != null && currentToggleIndex < toggles.Count-1)
        {
            scrollView.normalizedPosition += new Vector2(scrollSpeed, 0f);
            UpdateToggles();
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
        if (currentToggleIndex < toggles.Count - 1 && currentToggleIndex>=0)
        {
            currentToggleIndex++;
        }
        for (int i = 0; i < toggles.Count; i++)
        {
           if(i== currentToggleIndex)
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
