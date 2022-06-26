using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public TypeOfEquipment type;
    

    public StatsBlock modifiers;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveItemFromInventory();
    }
}

public enum TypeOfEquipment
{
    Head,
    Chest,
    Ring,
    Boots
}
