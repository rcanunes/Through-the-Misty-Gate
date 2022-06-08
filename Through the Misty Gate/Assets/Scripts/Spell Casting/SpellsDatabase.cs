using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellsDatabase : ScriptableObject
{
    public List<SpellScriptableObject> spells;


    public void OnEnable()
    {
        // Assign correct ids to the spells
        int i = 0;
        
        foreach (var spell in spells)
        {
            spell.spellId = i;
            i++;
        }
    }

    public void AssertCorrectIDs()
    {
        int i = 0;
        
        foreach (var spell in spells)
        {
            spell.spellId = i;
            i++;
        }
    }
}
