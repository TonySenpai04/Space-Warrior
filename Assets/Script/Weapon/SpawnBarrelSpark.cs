using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnBarrelSpark : ISpawn
{
    private Transform BarrelSpark;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    public SpawnBarrelSpark(Transform barrelSpark, Transform poolProjectile, Transform fXSocket, MonoBehaviour monoBehaviour)
    {
        BarrelSpark = barrelSpark;
        this.poolProjectile = poolProjectile;
        FXSocket = fXSocket;
        this.monoBehaviour = monoBehaviour;
    }

    public void Spawn()
    {
        if (BarrelSpark == null) return;
        var currentWeapon = WeaponController.instance.GetCurrentWeapon();
        if (!currentWeapon.IsInfiniteAmmo && currentWeapon.CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }
        Transform barrelSpark = PoolObjectManager.Instance.GetObjectFromPool(BarrelSpark, FXSocket, null);
        if (barrelSpark == null) return;
        barrelSpark.transform.SetParent(poolProjectile);
        monoBehaviour.StartCoroutine(DelayedDespawn(barrelSpark, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
 
    }
}
