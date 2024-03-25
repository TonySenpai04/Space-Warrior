using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("ToGold");
    }

}
