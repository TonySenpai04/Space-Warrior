using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public IHealth health;
    public IMana mana;
    public IDamage damage;
    public ILevel level;

    public ChacracterData chacracterData;
    public static CharacterStats instance;

    void Awake()
    {
        instance= this;
        health = new Health(chacracterData.health);
        mana = new Mana(chacracterData.mana);
        damage = new Damage(chacracterData.damage);
        level = new Level();
 
    }

}
