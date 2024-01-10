using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Custom/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public string name;
    public Sprite image;
    public float damage;

}
