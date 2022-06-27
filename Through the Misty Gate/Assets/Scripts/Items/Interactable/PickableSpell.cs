using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableSpell : Interactable
{
    public Spell spell;


    public override void Interact()
    {
        player.GetComponent<SpellCaster>().AddToKnowSpells(spell);
        Destroy(gameObject);
    }
}
