using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SpellBook : MonoBehaviour, IDropHandler, IPointerExitHandler, IDeselectHandler, IPointerDownHandler
{
    private Transform spellSlotTemplate;
    private Transform spellSlotContainer;

    private SpellBookSystem spellBookSystem;
    private HotKeySystem hotKeySystem;


    private RectTransform rectTransform;
    private Canvas canvas;

    [SerializeField] Transform spellInfo;


    private void OnEnable()
    {
        UpdateSpellBookVisual();
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (!LevelManager.instance.IsPointerOverUIElement("UI_Spells"))
            gameObject.SetActive(false);
    }

    private void Awake() {
        spellSlotContainer = transform.Find("ScrollView/Viewport/SpellSlotContainer");
        spellSlotTemplate = spellSlotContainer.Find("spellBookSlotTemplate");
        spellSlotTemplate.gameObject.SetActive(false);

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

    }

    public void SetSpellBookSystem(SpellBookSystem spellBookSystem, HotKeySystem hotKeySystem) {
        this.spellBookSystem = spellBookSystem;
        this.hotKeySystem = hotKeySystem;
        spellBookSystem.OnSpellChange += SpellBookSystem_OnSpellChange;


    }

    private void SpellBookSystem_OnSpellChange(object sender, EventArgs e) {
        if(LevelManager.instance.spellBookUI.activeSelf)
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
        if (eventData.pointerCurrentRaycast.gameObject == null)
            return;

        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(transform))
            return;

        DisableSpellInfo();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);

    }
}
