using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnSmoke : ISpawn
{
    private Transform Smoke;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    private List<Transform> smokeEffects;
    public SpawnSmoke(Transform Smoke, Transform poolProjectile, Transform FXSocket,
        MonoBehaviour monoBehaviour, List<Transform> smokeEffects)
    { 
        this.Smoke = Smoke;
        this.poolProjectile = poolProjectile;
        this.FXSocket = FXSocket;
        this.monoBehaviour = monoBehaviour;
        this.smokeEffects = smokeEffects;
    }
    public void Spawn()
    {
        if (Smoke == null) return; 
        var currentWeapon = WeaponController.instance.GetCurrentWeapon();
        if (!currentWeapon.IsInfiniteAmmo && currentWeapon.CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }
        Transform smoke = PoolObjectManager.Instance.GetObjectFromPool(Smoke, FXSocket, null);
        if (smoke == null) return;
        smokeEffects.Add(smoke.transform);
        smoke.transform.SetParent(poolProjectile);
         monoBehaviour.StartCoroutine(DelayedDespawn(smoke, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
    }
}
