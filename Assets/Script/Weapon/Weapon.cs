using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]private GenericWeapon weapon;
    void Start()
    {
        weapon = GetComponent<GenericWeapon>();
    }


   
}
