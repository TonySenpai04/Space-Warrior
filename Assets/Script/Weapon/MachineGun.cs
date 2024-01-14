using UnityEngine;
using System.Collections;

public class MachineGun : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        damage = 5;
        fireRate = 0.2f;
    }

}
