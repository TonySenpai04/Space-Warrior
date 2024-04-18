using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Currency
{
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("ToGold");
        StartCoroutine(TriggerAfterDelay(1f));
    }

}
