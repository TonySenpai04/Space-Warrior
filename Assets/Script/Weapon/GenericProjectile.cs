﻿using System;
using UnityEngine;
using System.Collections;

public class GenericProjectile : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private Collider2D _collider;
    private ParticleSystem _pSystem;
    public AudioSource Audio;
    public ShootingController.WeaponType WeaponType;

    //
    protected Vector3 _origin;

    //
    public Transform Hit;

    public bool PostHitHide;
    public float DelayDespawn;
    public float HitLifeTime;

    public virtual void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _pSystem = GetComponent<ParticleSystem>();
       
        _origin = transform.position;
    }

    public static void SpawnHit(Transform hitPrefab, Vector2 contactPoint, Vector2 contactNormal, Transform parent,
        float lifeTime)
    {
        if (hitPrefab == null) return;
        var hit = F3DSpawner.Spawn(hitPrefab, contactPoint, Quaternion.LookRotation(Vector3.forward, contactNormal),
            parent);
        F3DSpawner.Despawn(hit, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       

       

        // Send damage and spawn hit effects 
        

        var contacts = new ContactPoint2D[2];
        var contactsLength = other.GetContacts(contacts);

        if (contactsLength > 0)
        {
         

            var contact = other.contacts[0];

            DealDamage(5, WeaponType, contact.collider.transform, Hit, HitLifeTime, contact.point, contact.normal);

            // Play hit sound
       

            // Disable Physics if we have any
            if (_rBody != null && _collider != null)
            {
                _rBody.isKinematic = true;
                _collider.enabled = false;

                _rBody.simulated = false;
            }

            // Hide the sprite 
            if (PostHitHide)
            {
                _pSystem.Stop(true);
                _pSystem.Clear(true);
            }

            // Despawn self
            F3DSpawner.Despawn(transform, DelayDespawn);
        }

    }

    public static bool DealDamage(int damageAmount, ShootingController.WeaponType weaponType, Transform target,
        Transform hitPrefab, float hitLifeTime,
        Vector2 hitPoint, Vector2 hitNormal)
    {
        // Querry for F3DDamage
        if (target == null) return false;
        var damage = target.GetComponentInParent<F3DDamage>();
        if (damage == null) return false;

        //
        switch (damage.Type)
        {
            case F3DDamage.DamageType.Character:
                damage.OnDamage(damageAmount, hitPoint, hitNormal);
                switch (weaponType)
                {
                    case ShootingController.WeaponType.Pistol:
                        break;
                    case ShootingController.WeaponType.Assault:
                        break;
                    case ShootingController.WeaponType.Shotgun:
                        break;
                    case ShootingController.WeaponType.Machinegun:
                        break;
                    case ShootingController.WeaponType.Sniper:
                        break;
                    case ShootingController.WeaponType.Beam:
                        SpawnHit(hitPrefab, hitPoint, hitNormal, null, hitLifeTime);
                        break;
                    case ShootingController.WeaponType.Launcher:
                        break;
                    case ShootingController.WeaponType.EnergyHeavy:
                        break;
                    case ShootingController.WeaponType.Flamethrower:
                        break;
                    case ShootingController.WeaponType.Tesla:
                        break;
                    case ShootingController.WeaponType.Thrown:
                        break;
                    case ShootingController.WeaponType.Knife:
                        break;
                    case ShootingController.WeaponType.Melee:
                        break;
                    default:
                        break;
                }
                break;
            default:
                damage.OnDamage(damageAmount, hitPoint, hitNormal);
                SpawnHit(hitPrefab, hitPoint, hitNormal, null, hitLifeTime);
                break;
        }
        return true;
    }
}