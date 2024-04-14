using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour,IObserver
{
    private float totalTimeInSeconds;
    void Start()
    {
        totalTimeInSeconds = 0f;
    }
    public void Restart()
    {
        totalTimeInSeconds = 0f;
    }
    void Update()
    {
        if (!PlanetManager.instance.IsAreaFinish())
        {
            totalTimeInSeconds += Time.deltaTime;
        }
       
    }

    public string GetTime()
    {
        int minutes = (int)(totalTimeInSeconds / 60);
        int seconds = (int)(totalTimeInSeconds % 60);

        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    public void UpdateObserver()
    {
        Restart();
    }
    public float GetTimer()
    {
        return this.totalTimeInSeconds;
    }
}


