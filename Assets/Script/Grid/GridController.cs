using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Transform[] grids;
    [SerializeField] private float targetDistance;
    private IMove gridMove;

    void Start()
    {
        gridMove = new GridMove(player,grids,targetDistance);
    }

    void Update()
    {
      gridMove.Move();
    }

 
}
