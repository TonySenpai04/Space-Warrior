using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;
public class WeaponController : WeaponControllerBase
{
 
    [SerializeField] private bool RandomWeaponAtStart;
    [SerializeField] private int EquippedSlot;
    [SerializeField] private int EquippedWeapon;
    [SerializeField] private List<WeaponSlot> Slots;
    [SerializeField] private bool canShooting;
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
    [SerializeField] private Button btnShot;
    [SerializeField] private bool isShoot;
    [SerializeField] private AudioClip shootAudio;
    [SerializeField] private AudioSource shootAudioSource;
    public bool isTest=false;

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
        //if (RandomWeaponAtStart)
        //{
        //    EquippedSlot = UnityEngine.Random.Range(0, 5);
        //    EquippedWeapon = UnityEngine.Random.Range(0, 3);
        //}
 
        ActivateWeapon(EquippedSlot, EquippedWeapon);
        btnShot.onClick.AddListener(OnShoting);
    }
    public void OnShoting()
    {
        if (canShooting)
        {
            if (isShoot)
            {
                Slots[EquippedSlot].Weapons[EquippedWeapon].Fire();
                if (!GetCurrentWeapon().IsInfiniteAmmo && GetCurrentWeapon().CurrentAmmo <= 0)
                {

                    return;
                }
                shootAudioSource.PlayOneShot(Slots[EquippedSlot].Weapons[EquippedWeapon].audioShoot);
                SetTrigger("FireTrigger");
                nextFireTime = 0;
            }
        }
    }
    public override void StartShooting()
    {
        canShooting=true;
    }
    public override void StopShooting()
    {
        canShooting=false;
        SetBool("Fire", false);
    }
    public override void SetWeapon(int slot,int weaponIndex)
    {
        this.EquippedSlot=slot;
        this.EquippedWeapon=weaponIndex;
    }
    public override void Start() {
       
    }
    public override List<WeaponSlot> GetSlotListCopy()
    {
        return new List<WeaponSlot>(Slots);
    }
    public override void Shoot()
    {
        if (Input.GetKey(KeyCode.T))
        {
            isTest = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isTest = false;
            Time.timeScale = 1f;
        }
        if (isTest)
        {
            Time.timeScale = 10f;

        }
        
       

        if (canShooting)
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {
                isShoot = true;
                if (isTest)
                {
                    Slots[EquippedSlot].Weapons[EquippedWeapon].Fire();
                    if (!GetCurrentWeapon().IsInfiniteAmmo && GetCurrentWeapon().CurrentAmmo <= 0)
                    {

                        return;
                    }
                    SetTrigger("FireTrigger");
                    nextFireTime = 0;
                }
            }
            else
            {
                isShoot=false;
            }
        }
    }
    

    public override void Update()
    {

        // Switch Weapon Slot
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //    ActivateSlot(0);
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //    ActivateSlot(1);
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //    ActivateSlot(2);
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //    ActivateSlot(3);
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //    ActivateSlot(4);
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //    ActivateSlot(5);
        //if (Input.GetKeyDown(KeyCode.F))
        //    ActivateSlot(6);
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
    public override void Resstart()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            for (int j = 0; j < Slots[i].Weapons.Count; j++)
            {
                Slots[i].Weapons[j].CurrentAmmo = Slots[i].Weapons[j].AmmoCount;


            }
        }
    }
    public void SetFloat(string var, float value)
    {
        Slots[EquippedSlot].Weapons[EquippedWeapon].Animator.SetFloat(var, value);
    }
    public void SetTrigger(string var)
    {
        Slots[EquippedSlot].Weapons[EquippedWeapon].Animator.SetTrigger(var);
    }
    public override Tuple<int,int> GetWeaponIndex(GenericWeapon weapon)
    {
        int index = 0;
        int slot=0;
        for(int i = 0;i< Slots.Count; i++)
        {
            for(int j= 0;j< Slots[i].Weapons.Count;j++)
            {
                if (Slots[i].Weapons[j] == weapon)
                {
                    index = i;
                    slot = j;
                    break;
                }
            }
        }
        return Tuple.Create(index,slot);
    }
    public override GenericWeapon GetWeapon(int slot, int weapon)
    {
        
        return Slots[slot].Weapons[weapon];
    }
    public override void ActivateWeapon(int slot, int weapon)
    {
        Slots[slot].WeaponSlotCounter = weapon;
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

    public override GenericWeapon GetCurrentWeapon()
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
 
    

