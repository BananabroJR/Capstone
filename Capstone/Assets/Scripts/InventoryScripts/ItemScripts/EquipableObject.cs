using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    SWORD,
    AXE,
    ARMOR
}

[CreateAssetMenu(menuName = "EquipableObject")]
public class EquipableObject : ItemObject
{
    public float might;
    public float protection;
    public WeaponType weaponType;
    private void Awake()
    {
        type = ItemType.Equipable;
    }

    
}
