using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCoolDown: MonoBehaviour
{
    // Start is called before the first frame update
    public Spell spell;
    float currentTime;

    public SpellCoolDown(Spell spell)
    {
        this.spell = spell;
        currentTime = 0;
    }

    public void Update()
    {
        if(currentTime >= spell.cooldown)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;

    }
}
