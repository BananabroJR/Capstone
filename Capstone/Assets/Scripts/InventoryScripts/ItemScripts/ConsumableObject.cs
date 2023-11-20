using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConsumableObject")]
public class ConsumableObject : ItemObject
{
   
    public float restoreHealth;

    private void Awake()
    {
        type = ItemType.Consumable;
    }
}
