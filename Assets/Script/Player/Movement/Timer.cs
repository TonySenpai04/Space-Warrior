using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    private float totalTimeInSeconds;
    void Start()
    {
        totalTimeInSeconds = 0f;
    }

    void Update()
    {
        totalTimeInSeconds += Time.deltaTime;
    }

    // Lấy thời gian dưới dạng chuỗi "giờ:phút:giây"
    public string GetTime()
    {
        int minutes = (int)(totalTimeInSeconds / 60);
        int seconds = (int)(totalTimeInSeconds % 60);

        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

}


