using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Currency
{
    public override void Start()
    {
        base.Start();
        target = GameObject.Find("ToSoul");
        StartCoroutine(TriggerAfterDelay(1f));
    }
}
