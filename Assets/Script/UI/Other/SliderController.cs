using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{

    public bool isRunning = true;
    public Slider slider;
    public float speed = 0.5f;

    float time = 0f;
    public GameObject main;
    public GameObject panelControl;
	public GameObject loading;
	public GameObject currency;
    public TipController tipController;

    void Start()
	{
        
        slider = GetComponent<Slider>();

    }

    void Update()
    {
        if (isRunning)
        {
            UpdateSliderValue();
            CheckSliderCompletion();
        }
    }

    void UpdateSliderValue()
    {
        time += Time.deltaTime * speed;
        slider.value = time;
        tipController.ShowRandomTip();
    }



    void CheckSliderCompletion()
    {
        if (time >= 1)
        {
            CompleteSlider();
           
        }
    }

    void CompleteSlider()
    {
        loading.SetActive(false);
        main.SetActive(true);
        panelControl.SetActive(true);
        currency.SetActive(true);
        time = 0;
        tipController.ResetRandomTip();
    }

}
