using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookSystem {
    private SpellCastingManager player;
    private List<UI_ItemManager.HotKeyAbility> allSpells;
    public event EventHandler OnSpellChange;

    public bool toogleSpellBook;

    public SpellBookSystem(SpellCastingManager player) {
        this.player = player;
        //Adding to Inventory of Spells
        allSpells = new List<UI_ItemManager.HotKeyAbility>();

        foreach (var s in player.GetUnlockedSpells()) {
            allSpells.Add(new UI_ItemManager.HotKeyAbility {
                spell = s,
                spellId = s.spellId,
                activateSpell = () => player.SetCurrentSpell(s.spellId)
            });
        }
    }

    public List<UI_ItemManager.HotKeyAbility> GetAllSpells() {
        return allSpells;
    }

    public void InvokeOnSpellChange() {
        OnSpellChange?.Invoke(this, EventArgs.Empty);
    }

}
