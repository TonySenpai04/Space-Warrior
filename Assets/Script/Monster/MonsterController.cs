using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : EnemyController
{
    public static MonsterController instance;
    public override void Start()
    {
        base.Start();
        instance = this;
    }
  
}
