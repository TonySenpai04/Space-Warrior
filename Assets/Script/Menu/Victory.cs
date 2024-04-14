using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField]private List<Toggle> stars;
    public void SetStar(int stars)
    {
        
        for(int i = 0; i < stars; i++)
        {
            this.stars[i].isOn = true;
        }
    }
}
