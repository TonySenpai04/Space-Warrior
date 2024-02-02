using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounterUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI distanceText;
    private IDistanceCounter distanceCounter;
    private void Start()
    {
        distanceCounter = new DistanceCounter(FindAnyObjectByType<MovementControllerBase>().gameObject);
        if (distanceText != null ) {
            distanceText.text = "0";
        }
    }
    private void Update()
    {
        if (distanceCounter != null)
        {
            distanceCounter.UpdateDistance();
            distanceText.text = ((int)distanceCounter.GetTotalDistance()).ToString();
        }
    }
}
