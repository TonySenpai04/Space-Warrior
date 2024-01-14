using UnityEngine;
using System.Collections;

public class Assault : GenericWeapon
{
    public override void Awake()
    {
        base.Awake();
        fireRate = 0.12f;
        damage = 3f;
        
    }
}