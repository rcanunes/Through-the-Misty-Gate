using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spells_UI.Spellbook;
using Spells_UI.Spell_Bar;
using Spell_Casting;

namespace Spells_UI {
    public class UI_ItemManager : MonoBehaviour {

        //[SerializeField] Spells player;
        [SerializeField] private SpellCastingManager player;
        [SerializeField] UI_HotKeyBar uiHotKeyBar;
        [SerializeField] UI_SpellBook uiSpellBook;

        private HotKeySystem hotKeySystem;
        private SpellBookSystem spellBookSystem;

    private void Start()
    {
        hotKeySystem = new HotKeySystem(player);
        spellBookSystem = new SpellBookSystem(player);
        uiSpellBook.SetSpellBookSystem(spellBookSystem, hotKeySystem);
        uiHotKeyBar.SetHotKeySystem(hotKeySystem, spellBookSystem);

        }

        void Update() {
            hotKeySystem.Update();
        }

        public enum SpellType {
            Fireball,
            Shield,
            LightSword,
            Boost,
            SoundWave,
            HydroPump

        }

        public class HotKeyAbility {
            public SpellScriptableObject spell;
            public int spellId;
            public Action activateSpell;

            public Sprite GetSprite() {
                return spell.uiSprite;
            }
        }

        public void SetSBBAsLastChild() {
            uiSpellBook.transform.SetAsLastSibling();

        }

        public void SetHTSAsLastChild() {
            uiHotKeyBar.transform.SetAsLastSibling();
        }

    }
}