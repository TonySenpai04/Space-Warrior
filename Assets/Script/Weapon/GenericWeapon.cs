using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GenericWeapon : MonoBehaviour
{
    [Header("General")] public Animator Animator;
    public Transform Bone;
    public Transform PowerUp;

    // Hands
    public SpriteRenderer LeftHand;
    public SpriteRenderer RightHand;
    public int LeftHandId;
    public int RightHandId;

    // Weapon 
    [Header("Weapon")]
    public ShootingController.WeaponType weaponType;
    public float force;

    // Sockets
    [Header("Sockets")]
    public Transform FXSocket;
    public Transform ShellSocket;

    // Prefabs
    [Header("Prefabs")] 
    public Transform MuzzleFlash;

    public Transform Projectile;
    public Transform Shell;
    public Transform Smoke;
    public Transform BarrelSpark;

    [Header("Weapon Settings")]
    public float damage;
    public float fireRate;


    [SerializeField]protected Collider2D[] colliders;

    private List<Transform> barrelEffects = new List<Transform>();
    private List<Transform> smokeEffects = new List<Transform>();

    public virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        colliders = transform.root.GetComponentsInChildren<Collider2D>();

    }

    public void OnEnable()
    {
        if (Bone != null)
        {
            Animator.enabled = false;
            Bone.rotation = Quaternion.identity;
            Bone.localRotation = Quaternion.identity;
            Animator.enabled = true;
        }
       
    }

    public void OnDisable()
    {
        if (Bone != null)
        {
            Animator.enabled = false;
            Bone.rotation = Quaternion.identity;
            Bone.localRotation = Quaternion.identity;
        }
      
    }

    // Use this for initialization
    private void Start() { }

    // Update is called once per frame
    private void Update()
    {
     
    }

    private void LateUpdate()
    {
        DragBarrelEffects();

       
    }

    public virtual void Fire(Transform poolProjectile)
    {
       OnFire(poolProjectile);
    }

    public virtual void Stop()
    {
    }

    // WEAPON
    protected virtual void OnFire(Transform poolProjectile)
    {
        if (weaponType == ShootingController.WeaponType.Knife) return;

        SpawnShell(poolProjectile);
        SpawnMuzzleFlash(poolProjectile);
        if (this.weaponType == ShootingController.WeaponType.Beam)
            SpawnBeam(Projectile);
        else
            SpawnProjectile( poolProjectile);
        SpawnSmoke(poolProjectile);
        SpawnBarrelSpark(poolProjectile);

       
    }

    protected void SpawnShell(Transform poolProjectile)
    {
        
        // Spawn 
        if (Shell == null) return;
        GameObject shell = Instantiate(Shell.gameObject, FXSocket.transform.position, Quaternion.identity, null);
        shell.transform.SetParent(poolProjectile);

        // Despawn
        F3DSpawner.Despawn(shell.transform, 1.5f);
    }

    protected void SpawnMuzzleFlash(Transform poolProjectile)
    {
        //// Spawn 
        if (MuzzleFlash == null) return;
        var muzzleFlash = Instantiate(MuzzleFlash.gameObject, FXSocket.transform.position, Quaternion.identity, FXSocket);
        barrelEffects.Add(muzzleFlash.transform);
        muzzleFlash.transform.SetParent(poolProjectile);
        // Despawn
        F3DSpawner.Despawn(muzzleFlash.transform, 1f);
    }

    protected void SpawnProjectile(Transform poolProjectile)
    {
       
        GameObject projectile = Instantiate(Projectile.gameObject, FXSocket.transform.position, Quaternion.identity);
        projectile.transform.SetParent(poolProjectile);
        // Set Weapon Type
        var projectileObject = projectile.GetComponent<GenericProjectile>();
        projectileObject.WeaponType = weaponType;
        var projRb = projectile.GetComponent<Rigidbody2D>();
        // Launch  
        projRb.AddForce(projectile.transform.right * force, ForceMode2D.Force);
        Destroy(projectile, 3f);
    }

   
    protected void SpawnBeam(Transform projectilePrefab)
    {
        // Spawn
        GameObject beam = Instantiate(projectilePrefab.gameObject, FXSocket.transform.position, Quaternion.identity);
        beam.transform.SetParent(projectilePrefab);
        // Set Weapon Type
        var projectileObject = beam.GetComponent<Pulse>();
        projectileObject.WeaponType = weaponType;
      
    }

    protected void SpawnSmoke(Transform poolProjectile)
    {
        GameObject smoke = Instantiate(Smoke.gameObject,FXSocket.transform.position, Quaternion.identity);
        smokeEffects.Add(smoke.transform);
        smoke.transform.SetParent(poolProjectile);
        Destroy(smoke, 1f);
    }

    protected void SpawnBarrelSpark(Transform poolProjectile)
    {   
        var barrelSpark =Instantiate(BarrelSpark.gameObject, FXSocket.transform.position, Quaternion.identity);
        barrelSpark.transform.SetParent(poolProjectile);
        Destroy(barrelSpark,1f);
    }

    private void DragBarrelEffects()
    {
        for (var i = barrelEffects.Count - 1; i >= 0; i--)
        {
            if (barrelEffects[i] == null)
            {
                barrelEffects.RemoveAt(i);
                continue;
            }

        }

        // Smoke
        for (var i = smokeEffects.Count - 1; i >= 0; i--)
        {
            if (smokeEffects[i] == null)
            {
                smokeEffects.RemoveAt(i);
                continue;
            }
            smokeEffects[i].position = FXSocket.position;
        }
    }

}