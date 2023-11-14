using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterStats")]
public class StatObject : ScriptableObject
{
    public float health;
    public float mana;
    public float strength;
    public float magic;
    public float defense;


    
   
    public void EquipDamage(float damageMod)
    {
        strength += damageMod;
    }
    
    public void EquipDefense(float defenseMod)
    {
        defense += defenseMod;  

    }

    public void Damage(float damage)
    {
       
        health -= damage;
    }

   
}
