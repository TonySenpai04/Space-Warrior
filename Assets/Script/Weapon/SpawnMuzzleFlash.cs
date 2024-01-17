using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnMuzzleFlash : ISpawn
{
    private Transform MuzzleFlash;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    private List<Transform> barrelEffects ;
    public SpawnMuzzleFlash(Transform MuzzleFlash, Transform poolProjectile, Transform FXSocket, MonoBehaviour monoBehaviour,
        List<Transform> barrelEffects) 
    { 
        this.MuzzleFlash = MuzzleFlash;
        this.poolProjectile = poolProjectile;
        this.FXSocket = FXSocket;
        this.monoBehaviour = monoBehaviour;
        this.barrelEffects = barrelEffects;
    }
    public void Spawn()
    {
        if (MuzzleFlash == null) return;
        // var muzzleFlash = Instantiate(MuzzleFlash.gameObject, FXSocket.transform.position, Quaternion.identity, FXSocket);
        Transform muzzleFlash = PoolObjectManager.Instance.GetObjectFromPool(MuzzleFlash, FXSocket, FXSocket);

        barrelEffects.Add(muzzleFlash.transform);
        muzzleFlash.transform.SetParent(poolProjectile);
        // Despawn
       monoBehaviour.StartCoroutine(DelayedDespawn(muzzleFlash.transform, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
    }


}
