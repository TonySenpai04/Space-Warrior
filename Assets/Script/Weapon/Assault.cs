using UnityEngine;
using System.Collections;

public class Assault : GenericWeapon
{
    public override void Awake()
    {
        base.Awake();
        FireRate = 0.5f;
        Damage = 15f;
        
    }
}