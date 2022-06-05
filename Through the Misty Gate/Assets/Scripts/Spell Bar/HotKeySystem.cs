using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeySystem {

    // Update is called once per frame

    private Spells player;
    private List<HotKeyAbility> abilities;

    public event EventHandler OnAbilityListChange;

    public HotKeySystem(Spells player)
    {
        this.player = player;
        abilities = new List<HotKeyAbility>();

        abilities.Add(new HotKeyAbility
        {
            spellType = SpellType.Fireball,
            activateSpell = () => player.SetSpell(Spells.Spell.Fireball)

        });
        abilities.Add(new HotKeyAbility
        {
            spellType = SpellType.Shield,
            activateSpell = () => player.SetSpell(Spells.Spell.Shield)

        });
        abilities.Add(new HotKeyAbility
        {
            spellType = SpellType.LightSword,
            activateSpell = () => player.SetSpell(Spells.Spell.LightSword)

        });
        abilities.Add(new HotKeyAbility
        {
            spellType = SpellType.Boost,
            activateSpell = () => player.SetSpell(Spells.Spell.Boost)

        });

    }

    public enum SpellType
    {
        Fireball,
        Shield,
        LightSword,
        Boost
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilities[0].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilities[1].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilities[2].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilities[3].activateSpell();
            OnAbilityListChange?.Invoke(this, EventArgs.Empty);
        }
    }

    public class HotKeyAbility
    {
        public SpellType spellType;
        public Action activateSpell;

        public Sprite GetSprite()
        {
            switch (spellType)
            {
                default:
                case SpellType.Fireball:
                    return SpellsAssetContainer.Instance.FireballSprite;
                case SpellType.Boost:
                    return SpellsAssetContainer.Instance.BoostSprite;
                case SpellType.LightSword:
                    return SpellsAssetContainer.Instance.LightSwordSprite;
                case SpellType.Shield:
                    return SpellsAssetContainer.Instance.ShieldSprite;
             
            }
        }
    }

    public void SwapAbility(int indexA, int indexB)
    {
        HotKeyAbility ability = abilities[indexA];
        abilities[indexA] = abilities[indexB];
        abilities[indexB] = ability;
        OnAbilityListChange?.Invoke(this, EventArgs.Empty);

    }

    public List<HotKeyAbility> GetAbilities()
    {
        return abilities;
    }

    public SpellType GetCurrentSpell()
    {
        Spells.Spell current = player.GetCurrentSpell();
        switch (current)
        {
            default:
            case Spells.Spell.Fireball:
                return SpellType.Fireball;

            case Spells.Spell.Shield:
                return SpellType.Shield;

            case Spells.Spell.LightSword:
                return SpellType.LightSword;

            case Spells.Spell.Boost:
                return SpellType.Boost;
        }


    }
}
