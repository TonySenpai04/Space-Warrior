using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour,IObserver
{
    public IHealth health;
    public IMana mana;
    public IDamage damage;
    public ILevel level;

    public ChacracterData chacracterData;
    public static CharacterStats instance;

    public  bool isDead = false;

    void Awake()
    {
        instance= this;
        //health = new Health(chacracterData.health);
        //mana = new Mana(chacracterData.mana);
        //damage = new Damage(chacracterData.damage);
        //level = new Level();
 
    }
    public void Replay()
    {
        isDead = false;
        Restart();
    }
    public void SetData(ChacracterData chacracterData)
    {
        this.chacracterData = chacracterData;
        health = new Health(chacracterData.health);
        mana = new Mana(chacracterData.mana);
        damage = new Damage(chacracterData.damage,chacracterData.critRate);
        level = new Level();
    }
    public void Restart()
    {
        health.SetHealth(chacracterData.health);
        mana.SetMana(chacracterData.mana);
        damage.SetDam(chacracterData.damage);
        level.Restart();

    }
    public void UpdateObserver()
    {
        Restart();
    }
}
