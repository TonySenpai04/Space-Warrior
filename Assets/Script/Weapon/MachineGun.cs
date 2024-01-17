using UnityEngine;
using System.Collections;

public class MachineGun : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        Damage = 5;
        FireRate = 0.2f;
    }

}
