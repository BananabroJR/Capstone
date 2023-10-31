using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ThrowableObject")]
public class ThrowableObject : ItemObject
{
    public int damage;
    private void Awake()
    {
        type = ItemType.Throwable;
    }
}
