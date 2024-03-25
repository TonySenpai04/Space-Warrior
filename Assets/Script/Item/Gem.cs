using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("ToDiamond");
    }
}
