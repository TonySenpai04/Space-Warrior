using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnBeam : ISpawn
{
    private Transform Beam;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    private WeaponController.WeaponType weaponType;
    public SpawnBeam(Transform beam, Transform poolProjectile, Transform fXSocket, MonoBehaviour monoBehaviour, WeaponController.WeaponType weaponType)
    {
        this.Beam = beam;
        this.poolProjectile = poolProjectile;
        this. FXSocket = fXSocket;
        this.monoBehaviour = monoBehaviour;
        this.weaponType = weaponType;
    }

    public void Spawn()
    {
        if (Beam == null) return;
        var currentWeapon = WeaponController.instance.GetCurrentWeapon();
        if (!currentWeapon.IsInfiniteAmmo && currentWeapon.CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }
        Transform beam = PoolObjectManager.Instance.GetObjectFromPool(Beam, FXSocket, null);
        if (beam == null) return;
        beam.transform.SetParent(Beam);
        // Set Weapon Type
        var projectileObject = beam.GetComponent<Pulse>();
        projectileObject.WeaponType = weaponType;
        monoBehaviour.StartCoroutine(DelayedDespawn(beam, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
       
    }
}
