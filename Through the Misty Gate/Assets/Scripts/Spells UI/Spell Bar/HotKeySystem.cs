using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeySystem {

    // Update is called once per frame

    private Spells player;
    private List<UI_ItemManager.HotKeyAbility> spells;

    public event EventHandler OnAbilityListChange;

    public int MaxSpells = 7;

    public HotKeySystem(Spells player)
    {
        this.player = player;
        spells = new List<UI_ItemManager.HotKeyAbility>();

        spells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Fireball,
            activateSpell = () => player.SetSpell(Spells.Spell.Fireball)

        });
        spells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Shield,
            activateSpell = () => player.SetSpell(Spells.Spell.Shield)

        });
        spells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.LightSword,
            activateSpell = () => player.SetSpell(Spells.Spell.LightSword)

        });
        spells.Add(new UI_ItemManager.HotKeyAbility
        {
            spellType = UI_ItemManager.SpellType.Boost,
            activateSpell = () => player.SetSpell(Spells.Spell.Boost)
        });

        

    }


    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (spells.Count > 0)
                spells[0].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (spells.Count > 1)
                spells[1].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (spells.Count > 2)
                spells[2].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (spells.Count > 3)
                spells[3].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if(spells.Count > 4)
                spells[4].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (spells.Count > 5)
            {
                spells[5].activateSpell();
            }
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (spells.Count > 6)
                spells[6].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
    }

    internal void RemoveSpell(UI_ItemManager.HotKeyAbility hotKeyAbility)
    {
        if (CheckContainsSpell(hotKeyAbility) && spells.Count > 1)
        {

            spells.Remove(hotKeyAbility);

            if (GetCurrentSpell() == hotKeyAbility.spellType)
            {
                spells[0].activateSpell();
            }


        }

        

        OnAbilityListChange?.Invoke(this, EventArgs.Empty);
    }

    public void AddSpell(UI_ItemManager.HotKeyAbility hotKeyAbility)
    {
        if (!CheckContainsSpell(hotKeyAbility) && spells.Count < MaxSpells)
        {
            spells.Add(hotKeyAbility);
        }
        OnAbilityListChange?.Invoke(this, EventArgs.Empty);

    }

    public bool CheckContainsSpell(UI_ItemManager.HotKeyAbility check)
    {
        foreach (UI_ItemManager.HotKeyAbility spell in spells)
        {
            if (spell.spellType == check.spellType)
            {
                return true;
            }
        }
        return false;
    }

    public void SwapAbilityWithSpellBook(UI_ItemManager.HotKeyAbility newSpell, UI_ItemManager.HotKeyAbility oldSpell)
    {
        //Check if it exists on the hot bar
        if (CheckContainsSpell(newSpell))
        {
            return;
        }
        //get index
        int index = spells.IndexOf(oldSpell);

        //set
        spells[index] = newSpell;
        OnAbilityListChange?.Invoke(this, EventArgs.Empty);

    }

    public void SwapAbility(UI_ItemManager.HotKeyAbility spellA, UI_ItemManager.HotKeyAbility spellB)
    {
        if (spellA == null || spellB == null)
        {
            Debug.Log("Something was Null");
            return;
        }

        else
        {
            int indexA = spells.IndexOf(spellA);
            int indexB = spells.IndexOf(spellB);

            Debug.Log("Swapping" + indexA.ToString() + " " + indexB.ToString());

            UI_ItemManager.HotKeyAbility ability = spells[indexA];
            spells[indexA] = spells[indexB];
            spells[indexB] = ability;
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }

    }

    public List<UI_ItemManager.HotKeyAbility> GetSpells()
    {
        return spells;
    }


    public UI_ItemManager.SpellType GetCurrentSpell()
    {
        Spells.Spell current = player.GetCurrentSpell();
        switch (current)
        {
            default:
            case Spells.Spell.Fireball:
                return UI_ItemManager.SpellType.Fireball;

            case Spells.Spell.Shield:
                return UI_ItemManager.SpellType.Shield;

            case Spells.Spell.LightSword:
                return UI_ItemManager.SpellType.LightSword;

            case Spells.Spell.Boost:
                return UI_ItemManager.SpellType.Boost;
            case Spells.Spell.SoundWave:
                return UI_ItemManager.SpellType.SoundWave;

            case Spells.Spell.HydroPump:
                return UI_ItemManager.SpellType.HydroPump;
        }


    }
}
