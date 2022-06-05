using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_HotKeyBarSpellSlot : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler, IBeginDragHandler
{ 
    private HotKeySystem.HotKeyAbility hotKeyAbility;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;
    private int abilityIndex;
    private HotKeySystem hotKeySystem;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void SetUp(int index, HotKeySystem hotKeySystem, HotKeySystem.HotKeyAbility hotKeyAbility)
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
            if(uiHotKeyBarSpellSlot != null)
            {
                hotKeySystem.SwapAbility(abilityIndex, uiHotKeyBarSpellSlot.GetAbilityIndex());
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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }
}
