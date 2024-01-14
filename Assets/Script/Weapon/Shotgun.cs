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
        fireRate = 1f;
        damage = 12f;
    }


    protected override void OnFire()
    {
        
        // Muzzle Flash
        SpawnMuzzleFlash();
        if (Projectile)
            for (var i = 0; i < ProjectilesPerRound; i++)
                SpawnProjectile(Projectile);
        if (SparkFragment)
            for (var i = 0; i < SparksPerRound; i++)
                SpawnProjectile(SparkFragment);
        SpawnSmoke();
        SpawnBarrelSpark();

        // Play Audio
      //  _weaponAudio.OnFire(AudioInfo);
    }
}