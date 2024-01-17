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
    public float Damage;
    public float FireRate;


    [SerializeField]protected Collider2D[] colliders;

    private List<Transform> barrelEffects = new List<Transform>();
    private List<Transform> smokeEffects = new List<Transform>();
    private ISpawn spawnShell;
    private ISpawn spawnProjectile;
    private ISpawn spawnMuzzleFlash;
    private ISpawn spawnSmoke;
    private ISpawn spawnBarrelSpark;
    private ISpawn spawnBeam;
    private PoolObjectManager poolObjectManager;
    public virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        colliders = transform.root.GetComponentsInChildren<Collider2D>();
        poolObjectManager= FindAnyObjectByType<PoolObjectManager>();
        Transform poolProjectile = poolObjectManager.gameObject.transform;
        spawnShell = new SpawnShell(Shell, poolProjectile, FXSocket, this);
        spawnProjectile = new SpawnProjectile(Projectile, poolProjectile, FXSocket,
            this, weaponType, force);
        spawnMuzzleFlash = new SpawnMuzzleFlash(MuzzleFlash, poolProjectile, FXSocket, this,barrelEffects);
        spawnSmoke=new SpawnSmoke(Smoke, poolProjectile, FXSocket, this,smokeEffects);
        spawnBarrelSpark=new SpawnBarrelSpark(BarrelSpark, poolProjectile, FXSocket, this);
        spawnBeam=new SpawnBeam(poolProjectile, poolProjectile, FXSocket, this,weaponType);
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

    private void LateUpdate()
    {
        DragBarrelEffects();
       
    }

    public virtual void Fire()
    {
       OnFire();
    }

    public virtual void Stop()
    {
    }
   
    // WEAPON
    protected virtual void OnFire()
    {
        if (weaponType == ShootingController.WeaponType.Knife) return;

        spawnShell.Spawn();
        spawnMuzzleFlash.Spawn();
        if (this.weaponType == ShootingController.WeaponType.Beam)
            spawnBeam.Spawn();
        else
            spawnProjectile.Spawn();
        spawnSmoke.Spawn();
        spawnBarrelSpark.Spawn();

       
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