using UnityEngine;
using System.Collections;

public class Pistol : GenericWeapon
{
    public override void Awake()
    {
        base.Awake();
        fireRate = 0.5f;
        damage = 6f;
    }

}