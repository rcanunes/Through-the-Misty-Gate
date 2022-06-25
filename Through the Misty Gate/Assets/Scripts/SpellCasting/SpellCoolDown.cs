using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCoolDown: MonoBehaviour
{
    // Start is called before the first frame update
    public Spell spell;
    float currentTime;
    SpellCaster spellCaster;
    
    public void Initialize(SpellCaster spellCaster, Spell spell)
    {
        this.spellCaster = spellCaster;
        this.spell = spell;
    }

    public void Update()
    {
        if(currentTime >= spell.cooldown)
        {
            spellCaster.RemoveCoolDown(this);
            Destroy(this);
        }

        currentTime += Time.deltaTime;

    }

    public float CurrentRatio()
    {
        return currentTime / spell.cooldown;
    }
}
