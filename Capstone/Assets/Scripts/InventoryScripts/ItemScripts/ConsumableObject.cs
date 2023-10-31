using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConsumableObject")]
public class ConsumableObject : ItemObject
{
    public int restoreHealthValue;
    

    private void Awake()
    {
        type = ItemType.Consumable;
    }
}
