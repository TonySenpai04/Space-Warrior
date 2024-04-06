using System;
using UnityEngine;
using System.Collections;

public class GenericProjectile : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private Collider2D _collider;
    private ParticleSystem _pSystem;
    public AudioSource Audio;
    public WeaponController.WeaponType WeaponType;

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

    //public static void SpawnHit(Transform hitPrefab, Vector2 contactPoint, Vector2 contactNormal, Transform parent,
    //    float lifeTime)
    //{
    //    if (hitPrefab == null) return;
    //    var hit = F3DSpawner.Spawn(hitPrefab, contactPoint, Quaternion.LookRotation(Vector3.forward, contactNormal),
    //        parent);
       
    //}

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy monster = collision.gameObject.GetComponent<Enemy>();
        if (monster != null)
        {
            gameObject.SetActive(false);
            var currentWeapon = WeaponController.instance.GetCurrentWeapon();
            monster.TakeDamage(currentWeapon.DamageRate*CharacterStats.instance.damage.GetDam(),Color.red);
        }


    }
}