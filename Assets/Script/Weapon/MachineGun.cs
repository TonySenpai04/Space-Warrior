using UnityEngine;
using System.Collections;

public class MachineGun : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        DamageRate = 2.5f;
        FireRate = 0.7f;
    }

}
