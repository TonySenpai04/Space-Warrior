using UnityEngine;
using System.Collections;

public class MachineGun : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        Damage = 20f;
        FireRate = 0.7f;
    }

}
