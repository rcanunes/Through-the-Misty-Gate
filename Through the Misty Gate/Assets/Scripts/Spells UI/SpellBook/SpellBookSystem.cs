using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookSystem
{
    private Spells player;
    private List<UI_ItemManager.HotKeyAbility> allSpells;
    public event EventHandler OnSpellChange;


    public SpellBookSystem(Spells player)
    {
        this.player = player;
        //Adding to Inventory of Spells

        allSpells = new List<UI_ItemManager.HotKeyAbility>();

        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Fireball,
            activateSpell = () => player.SetSpell(Spells.Spell.Fireball)

        });
        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Shield,
            activateSpell = () => player.SetSpell(Spells.Spell.Shield)

        });
        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.LightSword,
            activateSpell = () => player.SetSpell(Spells.Spell.LightSword)

        });
        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Boost,
            activateSpell = () => player.SetSpell(Spells.Spell.Boost)
        });

        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.SoundWave,
            activateSpell = () => player.SetSpell(Spells.Spell.SoundWave)

        });
        allSpells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.HydroPump,
            activateSpell = () => player.SetSpell(Spells.Spell.HydroPump)

        });

    }

    public List<UI_ItemManager.HotKeyAbility> GetAllSpells()
    {
        return allSpells;
    }

    public void InvokeOnSpellChange()
    {
        OnSpellChange?.Invoke(this, EventArgs.Empty);
    }
}
