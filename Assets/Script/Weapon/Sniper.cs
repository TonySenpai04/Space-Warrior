using UnityEngine;
using System.Collections;

public class Sniper : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        FireRate = 1f;
        Damage = 15f;
    }

}
