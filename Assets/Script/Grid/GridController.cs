using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour,IObserver
{
    [SerializeField] private Transform player;
    [SerializeField] public Transform[] grids;
    [SerializeField] private float targetDistance;
    [SerializeField] public Vector2[] gridsStartPos=new Vector2[3];
    [SerializeField] private Vector3 playerStartPos;
    private IMove gridMove;

    void Start()
    {
        gridMove = new GridMove(player,grids,targetDistance);
        for(int i=0;i < grids.Length; i++)
        {
            gridsStartPos[i]= grids[i].transform.position;
        }
        playerStartPos = player.transform.position;
    }

    void Update()
    {
      gridMove.Move();
    }
    public void Restart()
    {
        for (int i = 0; i < gridsStartPos.Length; i++)
        {
            grids[i].transform.position = gridsStartPos[i];
        }
        player.transform.position = playerStartPos;
    }

    void IObserver.UpdateObserver()
    {
        Restart();
    }
}
