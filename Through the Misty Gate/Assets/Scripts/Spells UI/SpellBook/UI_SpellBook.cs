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
    private int maxCellPerLine = 4;

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
        }
    }

    private bool ToogleKeysDown()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    private void ToogleSpellBook()
    {
        toogleSpellBook = !toogleSpellBook;
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
        int x = 0;
        int y = 0;
        float spellSlotCellSize = 50f;

        foreach (Transform child in spellSlotContainer)
        {
            if (child == spellSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (UI_ItemManager.HotKeyAbility spell in spellBookSystem.GetAllSpells())
        {
            if (x >= maxCellPerLine)
            {
                y--;
                x = 0;
            }

            Transform spellSlotTransform = Instantiate(spellSlotTemplate, spellSlotContainer);
            RectTransform spellSlotRectTransform = spellSlotTransform.GetComponent<RectTransform>();
            spellSlotRectTransform.anchoredPosition += new Vector2(x * spellSlotCellSize, y * spellSlotCellSize);
            spellSlotRectTransform.gameObject.SetActive(true);
            spellSlotRectTransform.Find("SpellIcon").GetComponent<Image>().sprite = spell.GetSprite();
            x++;
            spellSlotTransform.GetComponent<UI_SpellBookSlot>().SetUp(spellBookSystem, spell);

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
