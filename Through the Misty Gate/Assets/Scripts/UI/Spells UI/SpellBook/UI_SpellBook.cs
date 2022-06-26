using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SpellBook : MonoBehaviour, IDropHandler, IPointerExitHandler
{
    private Transform spellSlotTemplate;
    private Transform spellSlotContainer;

    private SpellBookSystem spellBookSystem;
    private HotKeySystem hotKeySystem;


    private RectTransform rectTransform;
    private Canvas canvas;

    [SerializeField] Transform spellInfo;




    private void Awake() {
        spellSlotContainer = transform.Find("SpellSlotContainer");
        spellSlotTemplate = spellSlotContainer.Find("spellBookSlotTemplate");
        spellSlotTemplate.gameObject.SetActive(false);

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

    }

    //public void OnDrag(PointerEventData eventData) {
    //    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    //}

    public void SetSpellBookSystem(SpellBookSystem spellBookSystem, HotKeySystem hotKeySystem) {
        this.spellBookSystem = spellBookSystem;
        this.hotKeySystem = hotKeySystem;
        spellBookSystem.OnSpellChange += SpellBookSystem_OnSpellChange;


    }

    private void SpellBookSystem_OnSpellChange(object sender, EventArgs e) {
        UpdateSpellBookVisual();
    }

    private void OnEnable()
    {
        UpdateSpellBookVisual();
    }

    private void UpdateSpellBookVisual() {


        foreach (Transform child in spellSlotContainer) {
            if (child == spellSlotTemplate) continue;
            Destroy(child.gameObject);
        }
           
        foreach (UI_ItemManager.HotKeyAbility spell in spellBookSystem.GetAllSpells())
        {
            Transform spellSlotTransform = Instantiate(spellSlotTemplate, spellSlotContainer);
            spellSlotTransform.gameObject.SetActive(true);
            spellSlotTransform.Find("SpellIcon").GetComponent<Image>().sprite = spell.GetSprite();
            spellSlotTransform.GetComponent<UI_SpellBookSlot>().SetUp(spellBookSystem, spell, hotKeySystem, spellSlotContainer);

            if (hotKeySystem.CheckContainsSpell(spell)) {
                spellSlotTransform.GetComponent<CanvasGroup>().alpha = 0.5f;
            }

        }
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null && LevelManager.instance.IsSpellBookVisible()) {
            UI_HotKeyBarSpellSlot uiHotKeyBarSpellSlot =
                eventData.pointerDrag.GetComponent<UI_HotKeyBarSpellSlot>();
            if (uiHotKeyBarSpellSlot != null) {
                uiHotKeyBarSpellSlot.RemoveSpell();
                UpdateSpellBookVisual();
            }
        }
    }

    private void DisableSpellInfo() {
        if(spellInfo.gameObject.activeSelf)
            spellInfo.GetComponent<SmallAnimation>().OnCLose();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(transform))
            {
                DisableSpellInfo();
                return;
            }
        }
    }
}
