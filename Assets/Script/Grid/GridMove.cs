using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMove : IMove
{
    private Transform player;
    private Transform[] grids;
    private float targetDistance;
    public GridMove(Transform player, Transform[] grids, float targetDistance)
    {
        this.player = player;
        this.grids = grids;
        this.targetDistance = targetDistance;
    }

    public void Move()
    {
        if (player.transform.position.x - grids[0].position.x >= targetDistance)
        {
            grids[2].GetComponentInChildren<Tilemap>().CompressBounds();
            Vector3Int size = grids[2].GetComponentInChildren<Tilemap>().size;
            int width = size.x;
            int height = size.y;
            grids[0].position = new Vector3(grids[grids.Length - 1].position.x + width, grids[0].position.y, grids[0].position.z);
            Transform temp = grids[0];
            //for (int i = grids.Length-2; i >0; i++)
            //{
            //    grids[i] = grids[i -1];
            //}
            

            grids[0] = grids[1];

            grids[1] = grids[2];

            // Gán giá trị lưu trữ từ temp vào grids[2]
            //grids[2] = temp;
            //grids[2] = grids[1];
            //grids[1] = grids[0];
            
            grids[2] = temp;
        }
    }
}
