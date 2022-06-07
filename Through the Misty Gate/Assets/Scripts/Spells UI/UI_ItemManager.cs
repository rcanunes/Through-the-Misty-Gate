using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemManager : MonoBehaviour
{
    // Update is called once per frame


    [SerializeField] Spells player;
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

    void Update()
    {
        hotKeySystem.Update();
    }

    public enum SpellType
    {
        Fireball,
        Shield,
        LightSword,
        Boost,
        SoundWave,
        HydroPump

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
                case SpellType.SoundWave:
                    return SpellsAssetContainer.Instance.SoundwaveSprite;
                case SpellType.HydroPump:
                    return SpellsAssetContainer.Instance.HydropumpSprite;

            }
        }
    }

    public void SetSBBAsLastChild()
    {
        uiSpellBook.transform.SetAsLastSibling();

    }

    public void SetHTSAsLastChild()
    {
        uiHotKeyBar.transform.SetAsLastSibling();
    }

}
