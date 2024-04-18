using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Currency
{
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("ToDiamond");
        StartCoroutine(TriggerAfterDelay(1f));
    }
}
