using UnityEngine;
using System.Collections;

public class Assault : GenericWeapon
{
    public override void Awake()
    {
        base.Awake();
        FireRate = 0.12f;
        Damage = 3f;
        
    }
}