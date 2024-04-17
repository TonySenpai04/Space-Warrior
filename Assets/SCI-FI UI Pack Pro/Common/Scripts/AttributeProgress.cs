 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttributeProgress : MonoBehaviour
{

    public bool b = true;
    public Slider slider;
    public float speed;
    float time = 0f;

    public void Start()
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


                b = false;
            }
        }
    }


}
