using UnityEngine;

public class ShootingControllerBase:MonoBehaviour
{
    [SerializeField]protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected IShooting shooting;
}