using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EquipableObject")]
public class EquipableObject : ItemObject
{
    public float might;
    public float protection;
    private void Awake()
    {
        type = ItemType.Equipable;
    }

    
}
