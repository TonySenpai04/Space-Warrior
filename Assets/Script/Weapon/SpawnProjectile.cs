using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnProjectile : ISpawn
{
    private Transform Projectile;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    public WeaponController.WeaponType weaponType;
    public float force;
    public SpawnProjectile(Transform projectile, Transform poolProjectile, Transform fXSocket, MonoBehaviour monoBehaviour, WeaponController.WeaponType weaponType, float force)
    {
        Projectile = projectile;
        this.poolProjectile = poolProjectile;
        this.FXSocket = fXSocket;
        this.monoBehaviour = monoBehaviour;
        this.weaponType = weaponType;
        this.force = force;
    }

    public void Spawn()
    {
        if (Projectile == null)
            return;
   
        Transform projectile = PoolObjectManager.Instance.GetObjectFromPool(Projectile, FXSocket, null);
        projectile.transform.SetParent(poolProjectile);
        // Set Weapon Type
        var projectileObject = projectile.GetComponent<GenericProjectile>();
        projectileObject.WeaponType = weaponType;
        var projRb = projectile.GetComponent<Rigidbody2D>();
        // Launch  
        //   projRb.AddForce(projectile.transform.right * force, ForceMode2D.Force);
        var currentWeapon = WeaponController.instance.GetCurrentWeapon();
        projRb.AddForce(currentWeapon.transform.right * force, ForceMode2D.Force);
    }
}
