using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]private List<GridController> grids;
    public static GridManager instance;
    void Start()
    {
        instance = this;
    }
    public GridController GetCurrentGrid()
    {
        GridController curretnGrid = null;
        for (int i=0;i<grids.Count;i++)
        {
            if (grids[i].isActiveAndEnabled) {

                curretnGrid= grids[i];
                break;

            }
        }
        return curretnGrid;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
