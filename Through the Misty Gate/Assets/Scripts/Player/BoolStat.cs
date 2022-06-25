using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolStat
{
    private List<bool> modifiers = new List<bool>();

    public bool GetValue()
    {
        foreach (bool item in modifiers)
        {
            if (item)
                return true;
        }
        return false;
    }

    public void AddModifier(bool modifier)
    {
        modifiers.Add(modifier);
    }
    public void RemoveModifier(bool modifier)
    {
        modifiers.Remove(modifier);
    }
}
