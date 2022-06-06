using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_HotKeyBarSpellSlot : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler, IBeginDragHandler
{ 
    private UI_ItemManager.HotKeyAbility hotKeyAbility;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;
    private int abilityIndex;
    private HotKeySystem hotKeySystem;

    private Transform hotKeyBar;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
       
    }
    public void SetUp(int index, HotKeySystem hotKeySystem, UI_ItemManager.HotKeyAbility hotKeyAbility)
    {
        this.hotKeyAbility = hotKeyAbility;
        this.abilityIndex = index;
        this.hotKeySystem = hotKeySystem;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public int GetAbilityIndex()
    {
        return abilityIndex;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            UI_HotKeyBarSpellSlot uiHotKeyBarSpellSlot = eventData.pointerDrag.GetComponent<UI_HotKeyBarSpellSlot>();
            UI_SpellBookSlot uiSpellBookSlot = eventData.pointerDrag.GetComponent<UI_SpellBookSlot>();


            if (uiHotKeyBarSpellSlot != null)
            {
                hotKeySystem.SwapAbility(hotKeyAbility, uiHotKeyBarSpellSlot.hotKeyAbility);
            }
            else if (uiSpellBookSlot != null)
            {
                if (hotKeyAbility == null)
                {
                    Debug.Log("Adding Spell");

                    hotKeySystem.AddSpell(uiSpellBookSlot.GetSpell());
                }
                else
                {
                    hotKeySystem.SwapAbilityWithSpellBook(uiSpellBookSlot.hotKeyAbility, hotKeyAbility);
                }
            }
 
        }

    }

    private void Start()
    {
        startAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startAnchoredPosition;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        transform.parent.transform.SetAsFirstSibling();



    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
        transform.parent.transform.SetAsLastSibling();



    }

    public void RemoveSpell()
    {
        hotKeySystem.RemoveSpell(hotKeyAbility);
    }
}
