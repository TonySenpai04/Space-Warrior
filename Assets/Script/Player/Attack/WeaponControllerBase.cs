using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public abstract class WeaponControllerBase : MonoBehaviour
{
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
    public virtual List<WeaponSlot> GetSlotListCopy()
    {
        return new List<WeaponSlot>();
    }
    public virtual void Awake()
    {

    }
    public virtual void Start()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void Shoot()
    {

    }
    public virtual void StartShooting()
    {


    }
    public virtual void StopShooting()
    {

    }
    public virtual void LookAtMonster(Vector3 pos)
    {

    }
    public virtual GenericWeapon GetWeapon(int slot, int weapon)
    {
        return null;
    }
    public virtual void ActivateWeapon(int slot, int weapon)
    {

    }
    public virtual Tuple<int, int> GetWeaponIndex(GenericWeapon weapon)
    {
        return Tuple.Create(0, 0);
    }
    public virtual GenericWeapon GetCurrentWeapon()
    {
        return null;
    }
    public virtual void SetWeapon(int slot, int weaponIndex)
    {

    }
}