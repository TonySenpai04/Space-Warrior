using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderRun : MonoBehaviour
{

    public bool b = true;
    public Slider slider;
    public float speed = 0.5f;

    float time = 0f;
    public GameObject main;
    public GameObject panelControl;
	public GameObject loading;
	public GameObject currency;
    void Start()
	{
        
        slider = GetComponent<Slider>();

	}

	void Update()
	{
		if (b)
		{
			time += Time.deltaTime * speed;
			slider.value = time;

			if (time >= 1)
			{

                loading.SetActive(false);
                this.main.SetActive(true);
				panelControl.SetActive(true);
                currency.SetActive(true);
                time = 0;
			}
		}
	}
	
	
	
}
