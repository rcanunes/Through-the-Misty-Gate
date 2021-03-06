using System;
using System.Collections.Generic;
using UnityEngine;

public class HotKeySystem {


    private SpellCaster player;
    private List<UI_ItemManager.HotKeyAbility> spells;

    public event EventHandler OnAbilityListChange;

    public int MaxSpells = 5;

    public HotKeySystem(SpellCaster player) {


        this.player = player;

        spells = new List<UI_ItemManager.HotKeyAbility>();

    }

    public void Update()
    {

        if (LevelManager.instance.inventoryUI.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (spells.Count > 0)
                spells[0].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (spells.Count > 1)
                spells[1].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (spells.Count > 2)
                spells[2].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (spells.Count > 3)
                spells[3].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            if (spells.Count > 4)
                spells[4].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            if (spells.Count > 5) {
                spells[5].activateSpell();
            }

            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            if (spells.Count > 6)
                spells[6].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }

        int index = GetIndex(GetCurrentSpell());

        if (index == -1)
        {
            if (spells.Count > 0)
            {
                spells[0].activateSpell();
                OnAbilityListChange?.Invoke(this, EventArgs.Empty);
            }
 
            else
                return;
        }


        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f) {
            if (index < spells.Count - 1)
                index++;
            if (spells.Count > index)
                spells[index].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }

        else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f) {
            if (index > 0)
                index--;
            if (spells.Count > index)
                spells[index].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }


    }

    private int GetIndex(Spell check) {
        for (int i = 0; i < spells.Count; i++) {
            if (spells[i].spell == check) {
                return i;
            }
        }

        return -1;
    }

    private void Remove(String spellName)
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].spell.spellName == spellName)
            {
                spells.RemoveAt(i);
                return;
            }
        }
    }

    internal void RemoveSpell(UI_ItemManager.HotKeyAbility hotKeyAbility) {

       
        Remove(hotKeyAbility.spell.spellName);
        if (GetCurrentSpell() == hotKeyAbility.spell) {
            if(spells.Count > 0)
            {
                spells[0].activateSpell();
            }
            else
                player.SetCurrentSpell(null);
        }
        

        OnAbilityListChange?.Invoke(this, EventArgs.Empty);
    }

    public void AddSpell(UI_ItemManager.HotKeyAbility hotKeyAbility) {
        if (!CheckContainsSpell(hotKeyAbility) && spells.Count < MaxSpells) {
            spells.Add(hotKeyAbility);
        }

        OnAbilityListChange?.Invoke(this, EventArgs.Empty);

    }

    public bool CheckContainsSpell(UI_ItemManager.HotKeyAbility check) {
        foreach (UI_ItemManager.HotKeyAbility spell in spells) {
            if (spell.spell == check.spell) {
                return true;
            }
        }

        return false;
    }

    public void SwapAbilityWithSpellBook(UI_ItemManager.HotKeyAbility newSpell,
        UI_ItemManager.HotKeyAbility oldSpell) {
        //Check if it exists on the hot bar
        if (CheckContainsSpell(newSpell)) {
            return;
        }

        //get index
        int index = spells.IndexOf(oldSpell);

        //set
        spells[index] = newSpell;
        OnAbilityListChange?.Invoke(this, EventArgs.Empty);

    }

    public void SwapAbility(UI_ItemManager.HotKeyAbility spellA, UI_ItemManager.HotKeyAbility spellB) {
        if (spellA == null || spellB == null) {
            return;
        }

        else {
            int indexA = spells.IndexOf(spellA);
            int indexB = spells.IndexOf(spellB);


            UI_ItemManager.HotKeyAbility ability = spells[indexA];
            spells[indexA] = spells[indexB];
            spells[indexB] = ability;
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }

    }

    public List<UI_ItemManager.HotKeyAbility> GetSpells() {
        return spells;
    }


    public Spell GetCurrentSpell() {
        return player.currentSpell;
    }

}
