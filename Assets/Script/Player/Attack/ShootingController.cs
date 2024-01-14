using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;
public class ShootingController : ShootingControllerBase
{
 
    [SerializeField]private bool RandomWeaponAtStart;
    [SerializeField] private int EquippedSlot;
    [SerializeField] private int EquippedWeapon;
    [SerializeField] private List<WeaponSlot> Slots;
    [SerializeField] private bool isShooting;
    public static ShootingController instance;
    //
    [SerializeField] private CharacterAvatar avatar;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFireTime;

    //
    [Serializable]
    public class WeaponSlot
    {
        [SerializeField] public List<GenericWeapon> Weapons;
        public int WeaponSlotCounter = 1;

        public void Forward()
        {
            WeaponSlotCounter++;
            if (WeaponSlotCounter >= Weapons.Count)
                WeaponSlotCounter = 0;
        }
    }

    public enum WeaponType
    {
        Pistol,
        Assault,
        Shotgun,
        Machinegun,
        Sniper,
        Beam,
        Launcher,
        EnergyHeavy,
        Flamethrower,
        Tesla,
        Thrown,
        Knife,
        Melee
    }

    private void Awake()
    {
        avatar = GetComponent<CharacterAvatar>();
        instance = this;
        if (RandomWeaponAtStart)
        {
            EquippedSlot = UnityEngine.Random.Range(0, 5);
            EquippedWeapon = UnityEngine.Random.Range(0, 3);
        }

        ActivateWeapon(EquippedSlot, EquippedWeapon);
    }
    public void IsShooting()
    {
        isShooting=true;
    }
    public void StopShooting()
    {
        isShooting=false;
    }
    private void Start() {
       
    }


    private void Update()
    {
        // Fire
        if (isShooting)
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {

                Slots[EquippedSlot].Weapons[EquippedWeapon].Fire();
                nextFireTime = 0;
            }
        }


        // Switch Weapon Slot
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActivateSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ActivateSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ActivateSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ActivateSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            ActivateSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            ActivateSlot(5);
        if (Input.GetKeyDown(KeyCode.F))
            ActivateSlot(6);
    }

    private void ActivateSlot(int slot)
    {
        if (slot > Slots.Count - 1) return;
        if (slot == EquippedSlot)
            Slots[EquippedSlot].Forward();
        EquippedSlot = slot;
        EquippedWeapon = Slots[EquippedSlot].WeaponSlotCounter;
        ActivateWeapon(EquippedSlot, EquippedWeapon);
    }
    public void SetBool(string var, bool value)
    {
        Slots[EquippedSlot].Weapons[EquippedWeapon].Animator.SetBool(var, value);
    }

    public void SetFloat(string var, float value)
    {
        Slots[EquippedSlot].Weapons[EquippedWeapon].Animator.SetFloat(var, value);
    }
   
    private void ActivateWeapon(int slot, int weapon)
    {
        EquippedSlot = slot;
        EquippedWeapon = weapon;
        for (var i = 0; i < Slots.Count; i++)
        {
            for (var y = 0; y < Slots[i].Weapons.Count; y++)
            {
                Slots[i].Weapons[y].gameObject.SetActive(slot == i && weapon == y);
                

            }
        }
        fireRate = Slots[slot].Weapons[weapon].fireRate;
        Slots[slot].Weapons[weapon].Projectile.GetComponent<GenericProjectile>().damage = Slots[slot].Weapons[weapon].damage;
        UpdateCharacterHands(avatar.Characters[avatar.CharacterId]);
    }



    // Weapon drop on character killed
    //public void Drop()
    //{
    //    var powerUpPrefab = Slots[EquippedSlot].Weapons[EquippedWeapon].PowerUp;
    //    if (powerUpPrefab != null)
    //    {
    //        // Random Rotation
    //        var rot = Slots[EquippedSlot].Weapons[EquippedWeapon].FXSocket.rotation *
    //                  Quaternion.Euler(0, 0, Random.Range(-5, 5));

    //        // Spawn
    //        var powerUp = F3DSpawner.Spawn(powerUpPrefab, Slots[EquippedSlot].Weapons[EquippedWeapon].FXSocket.position,
    //            rot, null);

    //        // Flip
    //        var powerUpFlip = Mathf.Sign(Slots[EquippedSlot].Weapons[EquippedWeapon].FXSocket.lossyScale.x);
    //        var curScale = powerUp.localScale;
    //        curScale.x *= powerUpFlip;
    //        powerUp.localScale = curScale;

    //        // Add random force / torque
    //        var powerUpRb = powerUp.GetComponent<Rigidbody2D>();
    //        powerUpRb.AddForce((Vector2)Slots[EquippedSlot].Weapons[EquippedWeapon].FXSocket.up * Random.Range(8, 12),
    //            ForceMode2D.Impulse);
    //        powerUpRb.AddTorque(Random.Range(-250, 250), ForceMode2D.Force);
    //    }

        // Deactivate components
    //    Slots[EquippedSlot].Weapons[EquippedWeapon].gameObject.SetActive(false);
    //    this.enabled = false;
    //}

    public GenericWeapon GetCurrentWeapon()
    {
        return Slots[EquippedSlot].Weapons[EquippedWeapon];
    }

    // Avatar Hands
    public void UpdateCharacterHands(CharacterAvatar.CharacterArmature armature)
    {
        var myWeapon = GetCurrentWeapon();
        myWeapon.LeftHand.sprite = GetSpriteFromHandId(myWeapon.LeftHandId, armature);
        myWeapon.RightHand.sprite = GetSpriteFromHandId(myWeapon.RightHandId, armature);
    }



    private Sprite GetSpriteFromHandId(int id, CharacterAvatar.CharacterArmature armature)
    {
        switch (id)
        {
            case 0:
                return armature.Hand1;
            case 1:
                return armature.Hand2;
            case 2:
                return armature.Hand3;
            case 3:
                return armature.Hand4;
            default:
                return armature.Hand1;
        }
    }
    public void LookAtMonster(Transform pos)
    {
        EquippedSlot = 0;
        EquippedWeapon = Slots[EquippedSlot].WeaponSlotCounter;
        Vector3 targetDirection = pos.position - Slots[0].Weapons[EquippedWeapon].transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Slots[0].Weapons[EquippedWeapon].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
 
    

