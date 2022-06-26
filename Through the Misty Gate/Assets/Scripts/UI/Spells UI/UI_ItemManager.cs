using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemManager : MonoBehaviour {

    //[SerializeField] Spells player;
    [SerializeField] private SpellCaster player;
    [SerializeField] UI_HotKeyBar uiHotKeyBar;
    [SerializeField] UI_SpellBook uiSpellBook;

    private HotKeySystem hotKeySystem;
    private SpellBookSystem spellBookSystem;
    private MetricsSaveData metricsSaveData;

    private void Start()
    {
    hotKeySystem = new HotKeySystem(player);
    spellBookSystem = new SpellBookSystem(player);
    uiSpellBook.SetSpellBookSystem(spellBookSystem, hotKeySystem);
    uiHotKeyBar.SetHotKeySystem(hotKeySystem, spellBookSystem);

        metricsSaveData = MetricsSaveData.instance;
    }



    void Update() {

        if(hotKeySystem != null)
            hotKeySystem.Update();

        List<HotKeyAbility> hotKeys = hotKeySystem.GetSpells();
        foreach (HotKeyAbility spellKey in hotKeys)
        {
            metricsSaveData.metricsData.AddSpellTimeInHorBar(spellKey.spell.spellName, Time.deltaTime);
        }
        
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
        public Spell spell;
        public Action activateSpell;

        public Sprite GetSprite() {
            return spell.image;
        }
    }

    public void SetSBBAsLastChild() {
        uiSpellBook.transform.SetAsLastSibling();

    }

    public void SetHTSAsLastChild() {
        uiHotKeyBar.transform.SetAsLastSibling();
    }

}
