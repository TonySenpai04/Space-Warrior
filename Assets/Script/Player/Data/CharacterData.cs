using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
[CreateAssetMenu(fileName = "Character Data", menuName = "Character Data")]
[System.Serializable]
public class ChacracterData : ScriptableObject
{

    public float health;
    public float mana;
    public float damage;
  
    public ChacracterData() { }

}

