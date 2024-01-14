﻿using UnityEngine;
using System.Collections;

public class Sniper : GenericWeapon {
    public override void Awake()
    {
        base.Awake();
        fireRate = 1f;
        damage = 15f;
    }

}
