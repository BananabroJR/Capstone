using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EquipableObject")]
public class EquipableObject : ItemObject
{
    public int might;
    public int protection;
    private void Awake()
    {
        type = ItemType.Equipable;
    }
}
