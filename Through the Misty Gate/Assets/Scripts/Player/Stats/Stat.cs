using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    public int baseValue;
    private List<int> modifiers = new List<int>();

    public float GetValue()
    {
        int finalValue = baseValue;

        modifiers.ForEach(x => finalValue += x);

        return finalValue * 0.01f;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);

    }
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
