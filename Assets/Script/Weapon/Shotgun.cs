using UnityEngine;
using System.Collections;

public class Shotgun : GenericWeapon
{
    public Transform SparkFragment;
    public int ProjectilesPerRound;
    public int SparksPerRound;

    public override void Awake()
    {
        base.Awake();
    }


    //protected override void OnFire(Transform poolProjectile)
    //{
        
    //    // Muzzle Flash
    //    SpawnMuzzleFlash(poolProjectile);
    //    if (Projectile)
    //        for (var i = 0; i < ProjectilesPerRound; i++)
    //            SpawnProjectile(Projectile);
    //    if (SparkFragment)
    //        for (var i = 0; i < SparksPerRound; i++)
    //            SpawnProjectile(SparkFragment);
    //    SpawnSmoke(poolProjectile);
    //    SpawnBarrelSpark(poolProjectile);

    //    // Play Audio
    //  //  _weaponAudio.OnFire(AudioInfo);
    //}
}