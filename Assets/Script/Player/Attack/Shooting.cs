using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : IShooting
{
    public GameObject weaponPrefab;
    public Transform firePoint;

    private int poolSize = 10;

    private List<GameObject> bulletPool;
    private int currentBulletIndex;
    public Shooting(GameObject weaponPrefab, Transform firePoint)
    {
        this.weaponPrefab = weaponPrefab;
        this.firePoint = firePoint;
        InitializeBulletPool();
    }
    private void InitializeBulletPool()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Object.Instantiate(weaponPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    public void Shoot()
    {
        GameObject bullet = GetNextBullet();

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
        //Object.Instantiate(weaponPrefab, firePoint.position, firePoint.rotation);
    }
    private GameObject GetNextBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            currentBulletIndex = (currentBulletIndex + 1) % poolSize;
            if (!bulletPool[currentBulletIndex].activeInHierarchy)
            {
                return bulletPool[currentBulletIndex];
            }
        }
        GameObject bullet = Object.Instantiate(weaponPrefab, Vector3.zero, Quaternion.identity);
        bulletPool.Add(bullet);
        return  bullet ; 
    }
}
