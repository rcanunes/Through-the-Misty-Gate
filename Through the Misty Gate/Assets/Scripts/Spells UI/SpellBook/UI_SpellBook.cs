using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SpellBook : MonoBehaviour, IDropHandler, IDragHandler
{
    private Transform spellSlotTemplate;
    private Transform spellSlotContainer;

    private SpellBookSystem spellBookSystem;
    private CanvasGroup canvasGroup;
    private HotKeySystem hotKeySystem;

    private bool toogleSpellBook;

    private RectTransform rectTransform;
    private Canvas canvas;



    private void Awake()
    {
        spellSlotContainer = transform.Find("SpellSlotContainer");

        spellSlotTemplate = spellSlotContainer.Find("spellBookSlotTemplate");
        spellSlotTemplate.gameObject.SetActive(false);


        //Hide Inventory
        canvasGroup = GetComponent<CanvasGroup>();
        toogleSpellBook = true;
        ToogleSpellBook();

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void SetSpellBookSystem(SpellBookSystem spellBookSystem, HotKeySystem hotKeySystem)
    {
        this.spellBookSystem = spellBookSystem;
        this.hotKeySystem = hotKeySystem;
        spellBookSystem.OnSpellChange += SpellBookSystem_OnSpellChange;

        UpdateSpellBookVisual();
    }

    private void SpellBookSystem_OnSpellChange(object sender, EventArgs e)
    {
        UpdateSpellBookVisual();
    }

    private void Update()
    {
        if (ToogleKeysDown())
        {
            ToogleSpellBook();
            UpdateSpellBookVisual();
            spellBookSystem.toogleSpellBook = toogleSpellBook;
        }
    }

    private bool ToogleKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    private void ToogleSpellBook()
    {
        toogleSpellBook = !toogleSpellBook;
        LevelManager.instance.SetInventoryVisivility( toogleSpellBook);
        if (toogleSpellBook)
        {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }

    private void UpdateSpellBookVisual()
    {
        foreach (Transform child in spellSlotContainer)
        {
            if (child == spellSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (UI_ItemManager.HotKeyAbility spell in spellBookSystem.GetAllSpells())
        {
            Transform spellSlotTransform = Instantiate(spellSlotTemplate, spellSlotContainer);
            spellSlotTransform.gameObject.SetActive(true);
            spellSlotTransform.Find("SpellIcon").GetComponent<Image>().sprite = spell.GetSprite();
            spellSlotTransform.GetComponent<UI_SpellBookSlot>().SetUp(spellBookSystem, spell, hotKeySystem);

            if (hotKeySystem.CheckContainsSpell(spell))
            {    
                spellSlotTransform.GetComponent<CanvasGroup>().alpha = 0.5f;
            }

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && toogleSpellBook)
        {
            UI_HotKeyBarSpellSlot uiHotKeyBarSpellSlot = eventData.pointerDrag.GetComponent<UI_HotKeyBarSpellSlot>();
            if (uiHotKeyBarSpellSlot != null)
            {
                uiHotKeyBarSpellSlot.RemoveSpell();
                UpdateSpellBookVisual();
            }
        }
    }
}
