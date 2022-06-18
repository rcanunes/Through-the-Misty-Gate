using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Invantory/Equipment")]

public class Equipment : Item
{
    public TypeOfEquipment type;
    public enum TypeOfEquipment
    {
        Head,
        Chest,
        Ring,
        Boots
    }

    public EquipmentPowers.Mods modifier;
}
