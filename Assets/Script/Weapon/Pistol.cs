using UnityEngine;
using System.Collections;

public class Pistol : GenericWeapon
{
    public override void Awake()
    {
        base.Awake();
        FireRate = 0.5f;
        DamageRate = 1f;
    }

}