using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]private Text timeText;
    [SerializeField] private Timer timer;
    private void Start()
    {
       timer=FindAnyObjectByType<Timer>();
        if (timeText != null ) {
            timeText.text = "0";
        }
    }
    private void Update()
    {
        if (timer != null)
        {
           
            timeText.text = timer.GetTime().ToString();
        }
    }
}
