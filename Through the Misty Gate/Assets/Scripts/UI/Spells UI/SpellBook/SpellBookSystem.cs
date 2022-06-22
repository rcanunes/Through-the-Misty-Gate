using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookSystem {
    private SpellCaster player;
    private List<UI_ItemManager.HotKeyAbility> allSpells;
    public event EventHandler OnSpellChange;

    public SpellBookSystem(SpellCaster player) {
        this.player = player;
        //Adding to Inventory of Spells
        allSpells = new List<UI_ItemManager.HotKeyAbility>();

        foreach (var s in player.GetKnownSpells()) {
            allSpells.Add(new UI_ItemManager.HotKeyAbility {
                spell = s,
                activateSpell = () => player.SetCurrentSpell(s)
            });
        }
    }

    public List<UI_ItemManager.HotKeyAbility> GetAllSpells() {
        return allSpells;
    }

    public void InvokeOnSpellChange() {
        OnSpellChange?.Invoke(this, EventArgs.Empty);
    }

    public void AddSpell()
    {
        
    }

}
