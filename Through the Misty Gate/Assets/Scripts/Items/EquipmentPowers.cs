using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPowers: MonoBehaviour
{
    static public EquipmentPowers instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Mods
    {
        Item1,
        Item2
    }

    public void ModifyPlayer(Mods type)
    {
        switch (type)
        {
            case Mods.Item1:
                break;
            case Mods.Item2:
                break;
            default:
                break;
        }
    }
}
