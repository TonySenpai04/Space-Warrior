using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnBeam : ISpawn
{
    private Transform projectilePrefab;
    private Transform poolProjectile;
    private Transform FXSocket;
    private MonoBehaviour monoBehaviour;
    private ShootingController.WeaponType weaponType;
    public SpawnBeam(Transform projectilePrefab, Transform poolProjectile, Transform fXSocket, MonoBehaviour monoBehaviour, ShootingController.WeaponType weaponType)
    {
        this.projectilePrefab = projectilePrefab;
        this.poolProjectile = poolProjectile;
        this. FXSocket = fXSocket;
        this.monoBehaviour = monoBehaviour;
        this.weaponType = weaponType;
    }

    public void Spawn()
    {
        Transform beam = PoolObjectManager.Instance.GetObjectFromPool(projectilePrefab, FXSocket, null);
        beam.transform.SetParent(projectilePrefab);
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
