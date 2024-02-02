using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : IDistanceCounter
{
    private float totalDistance = 0f;
    private GameObject player;
    private Vector3 startPoint;
    public DistanceCounter(GameObject player) 
    {
        this.player = player;
        startPoint=player.transform.position;


    }
    public float GetTotalDistance()
    {
        return totalDistance;
    }

    public void UpdateDistance()
    {
        float distance = player.transform.position.x - startPoint.x;
        totalDistance += distance;
        UpdateStartPoint();
    }
    private void UpdateStartPoint()
    {
        startPoint = player.transform.position;
    }
}
