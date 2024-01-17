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
        Transform barrelSpark = PoolObjectManager.Instance.GetObjectFromPool(BarrelSpark, FXSocket, null);
        barrelSpark.transform.SetParent(poolProjectile);
        monoBehaviour.StartCoroutine(DelayedDespawn(barrelSpark, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
 
    }
}
