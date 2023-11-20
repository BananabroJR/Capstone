using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UsingItems : MonoBehaviour
{
    public ItemObject item;
    public StatObject playerStats;
    public StatObject enemy;
    public InventoryObject inventory;

    private bool isAlreadyEquipped = false;

    private float currentStrengthMod = 0;
    private float currentDefenseMod = 0;

    public void UseItem()
    {
        if(item.type == ItemType.Equipable)
        {
            EquipableObject equipment = (EquipableObject)item;
            if(isAlreadyEquipped)
            {
                playerStats.UnEquipDamage(currentStrengthMod);
                playerStats.UnEquipDefense(currentDefenseMod);
                isAlreadyEquipped = false;
            }
            if(equipment.weaponType == WeaponType.SWORD)
            {
                BattleController.equippment = WeaponEquipped.SWORD;
                playerStats.EquipDamage(equipment.might);
                currentStrengthMod = equipment.might;
                isAlreadyEquipped = true;
            }
            if (equipment.weaponType == WeaponType.AXE)
            {
                BattleController.equippment = WeaponEquipped.AXE;
                playerStats.EquipDamage(equipment.might);
                currentStrengthMod = equipment.might;
                isAlreadyEquipped = true;
            }
            playerStats.EquipDefense(equipment.protection);
            currentDefenseMod = equipment.protection;
        }

        if(item.type == ItemType.Throwable)
        {
            ThrowableObject throwable = (ThrowableObject)item;
            enemy.Damage(throwable.damage);
            inventory.RemoveItem(item, 1);

        }

        if(item.type == ItemType.Consumable)
        {
            ConsumableObject consumable = (ConsumableObject)item;
            playerStats.Heal(consumable.restoreHealth);
            DestroyImmediate(item,true);
            inventory.RemoveItem(item, 1);
        }
    }

}
