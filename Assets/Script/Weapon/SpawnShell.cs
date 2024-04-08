using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class SpawnShell : ISpawn
{
    private Transform Shell;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    public SpawnShell(Transform shell,Transform poolProjectile, Transform FXSocket, MonoBehaviour monoBehaviour)
    {
        this.Shell = shell;
        this.poolProjectile = poolProjectile;
        this.FXSocket = FXSocket;
        this.monoBehaviour = monoBehaviour;
    }
    public void Spawn()
    {
        if (Shell == null) return;
        var currentWeapon = WeaponController.instance.GetCurrentWeapon();
        if (!currentWeapon.IsInfiniteAmmo && currentWeapon.CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }
        Transform shell = PoolObjectManager.Instance.GetObjectFromPool(Shell, FXSocket, null);
        if(shell == null) return;
        shell.transform.SetParent(poolProjectile);

        // Despawn
  
        monoBehaviour.StartCoroutine(DelayedDespawn(shell, 0.5f));
    }
    private IEnumerator DelayedDespawn(Transform obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolObjectManager.Instance.ReturnObjectToPool(obj);
    }
}
