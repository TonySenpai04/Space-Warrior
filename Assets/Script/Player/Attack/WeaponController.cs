using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;
public class WeaponController : WeaponControllerBase
{
 
    [SerializeField] private bool RandomWeaponAtStart;
    [SerializeField] private int EquippedSlot;
    [SerializeField] private int EquippedWeapon;
    [SerializeField] private List<WeaponSlot> Slots;
    [SerializeField] private bool isShooting;
    //
    [SerializeField] private CharacterAvatar avatar;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFireTime;
    [SerializeField] private Transform poolProjectile;
    //
    [SerializeField] private int crit;
    //
    public static WeaponController instance;
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

    public override void Awake()
    {
        avatar = FindAnyObjectByType<CharacterAvatar>();
        instance = this;
        if (RandomWeaponAtStart)
        {
            EquippedSlot = UnityEngine.Random.Range(0, 5);
            EquippedWeapon = UnityEngine.Random.Range(0, 3);
        }

        ActivateWeapon(EquippedSlot, EquippedWeapon);
    }
    public override void StartShooting()
    {
        isShooting=true;
    }
    public override void StopShooting()
    {
        isShooting=false;
        SetBool("Fire", false);
    }
    public override void Start() {
       
    }
    public override void Shoot()
    {
        if (isShooting)
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {

                Slots[EquippedSlot].Weapons[EquippedWeapon].Fire();
                SetTrigger("FireTrigger");
                nextFireTime = 0;
            }
        }
    }

    public override void Update()
    {

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
    public void SetTrigger(string var)
    {
        Slots[EquippedSlot].Weapons[EquippedWeapon].Animator.SetTrigger(var);
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
        fireRate = Slots[slot].Weapons[weapon].FireRate;
        UpdateCharacterHands(avatar.Characters[avatar.CharacterId]);
    }

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
    public override void LookAtMonster(Vector3 pos)
    {
        
        EquippedWeapon = Slots[EquippedSlot].WeaponSlotCounter;
        Vector3 targetDirection = pos- Slots[EquippedSlot].Weapons[EquippedWeapon].transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Slots[EquippedSlot].Weapons[EquippedWeapon].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
 
    

